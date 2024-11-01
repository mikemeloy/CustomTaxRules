using Newtonsoft.Json;
using Nop.Plugin.Tax.CustomRules.Enums;
using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Plugin.Tax.CustomRules.Models;

namespace Nop.Plugin.Tax.CustomRules.Factories;

internal class AddressLookup : IStepInit, IStepAddressStreet, IStepAddressCityStateZip, IUserKeyStep, IValidateStep
{
    private readonly IAddressVerificationUsageRepository _addressVerificationUsageRepository;
    private readonly IAddressRequest _addressRequest;
    private readonly HttpClient _httpClient;
    private readonly ILogging _log;
    private bool _isValid;
    public bool IsValid => _isValid;

    private AddressLookup(HttpClient httpClient, ILogging log, IAddressVerificationUsageRepository addressVerificationUsageRepository)
    {
        _addressRequest = new AddressRequest();
        _httpClient = httpClient;
        _log = log;
        _addressVerificationUsageRepository = addressVerificationUsageRepository;
    }
    public static IStepInit Init(HttpClient httpClient, IAddressVerificationUsageRepository addressVerificationUsageRepository, ILogging log)
    {
        return new AddressLookup(
                        httpClient: httpClient,
                        addressVerificationUsageRepository: addressVerificationUsageRepository,
                        log: log
                    );
    }
    public IStepAddressStreet SetStreet(string street)
    {
        _addressRequest.Street = street;
        return this;
    }
    public IStepAddressCityStateZip SetCityStateZip(string cityStateZip)
    {
        _addressRequest.CityStateZip = cityStateZip;
        return this;
    }
    public IUserKeyStep SetUserKey(string userKey)
    {
        _addressRequest.UserKey = userKey;
        return this;
    }
    public IValidateStep Validate()
    {
        var hasAddress = !string.IsNullOrEmpty(_addressRequest.Street);
        var hasAddressTwo = !string.IsNullOrEmpty(_addressRequest.CityStateZip);
        _isValid = hasAddress && hasAddressTwo;

        return this;
    }
    public async Task<IAddressResponse> GetAddress()
    {
        return IsValid
                ? await GetAddressAsync()
                : new AddressResponse
                {
                    ErrorCode = ErrorCode.System,
                    ErrorMessage = "Missing Address Information"
                };

    }
    private async Task<AddressResponse> GetAddressAsync()
    {
        var param = $"AddressLine1={_addressRequest.Street}&AddressLine2={_addressRequest.CityStateZip}";

        try
        {
            using var response = await _httpClient.GetAsync($"https://www.yaddress.net/api/Address?{param}");
            response.EnsureSuccessStatusCode();
            var rawResponse = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<AddressResponse>(rawResponse);
            await UpdateUsageStatisticsAsync(address.ErrorCode);
            return address;
        }
        catch (Exception e)
        {
            _log.LogError("Unable to validate address", e);
        }

        return new AddressResponse()
        {
            ErrorCode = ErrorCode.System,
            ErrorMessage = "Unable to return address"
        };
    }
    private async Task UpdateUsageStatisticsAsync(ErrorCode error)
    {
        var addressFound = error == ErrorCode.NoError;
        await _addressVerificationUsageRepository.UpdateUsageStatisticsAsync(addressFound);
    }
}

