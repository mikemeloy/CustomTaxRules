using Newtonsoft.Json;
using Nop.Plugin.Tax.CustomRules.Enums;
using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Plugin.Tax.CustomRules.Models;

namespace Nop.Plugin.Tax.CustomRules.Factories
{
    internal class AddressLookup : IStepInit, IStepAddressStreet, IStepAddressCityStateZip, IUserKeyStep, IValidateStep
    {
        private readonly IAddressRequest _addressRequest;
        private readonly HttpClient _httpClient;
        private bool _isValid;
        public AddressLookup(HttpClient httpClient)
        {
            _addressRequest = new AddressRequest();
            _httpClient = httpClient;
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
            return _isValid
                    ? await GetAddressAsync()
                    : new AddressResponse
                    {
                        ErrorCode = ErrorCode.System,
                        ErrorMessage = "Missing Address information"
                    };

        }
        private async Task<AddressResponse> GetAddressAsync()
        {
            var param = $"AddressLine1={_addressRequest.Street}&AddressLine2={_addressRequest.CityStateZip}";

            using var response = await _httpClient.GetAsync($"https://www.yaddress.net/api/Address?{param}");
            response.EnsureSuccessStatusCode();
            var rawResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AddressResponse>(rawResponse);
        }
    }
    public static class AddressLookupFactory
    {
        public static IStepInit Init(HttpClient httpClient) => new AddressLookup(httpClient);
    }
}
