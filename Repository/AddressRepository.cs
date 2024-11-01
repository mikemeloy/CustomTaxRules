using Nop.Core.Domain.Common;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Repository;

internal class AddressRepository : IAddressRepository
{
    private readonly Nop.Services.Common.IAddressService _addressService;
    private readonly Nop.Data.IRepository<Address> _addressRepository;
    private readonly ILogging _log;

    public AddressRepository(Nop.Services.Common.IAddressService addressService, Nop.Data.IRepository<Address> addressRepository, ILogging log)
    {
        _addressService = addressService;
        _addressRepository = addressRepository;
        _log = log;
    }
    public async Task<Address> GetAddressById(int id)
    {
        var address = await _addressService.GetAddressByIdAsync(id);

        return address;
    }
    public async Task UpdateAddressAsync(int? id, IAddressResponse apiResult)
    {
        if (!id.HasValue)
        {
            return;
        }

        var currentAddress = await _addressService.GetAddressByIdAsync(id.Value);
        currentAddress.Address1 = apiResult.AddressLine1;
        currentAddress.Address2 = apiResult.AddressLine2;
        currentAddress.City = apiResult.City;
        currentAddress.County = apiResult.County;
        currentAddress.CountryId = CustomTaxRuleDefaults.UnitedStatesCountryCode;
        currentAddress.ZipPostalCode = $"{apiResult.Zip}-{apiResult.Zip4}";

        var isValid = await _addressService.IsAddressValidAsync(currentAddress);

        if (!isValid)
        {
            return;
        }

        try
        {
            await _addressRepository.UpdateAsync(currentAddress, publishEvent: false);

        }
        catch (Exception e)
        {

            _log.LogError("Failed to update address record", e);
        }
    }
}

