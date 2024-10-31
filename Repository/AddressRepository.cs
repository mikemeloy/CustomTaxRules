using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Repository
{
    internal class AddressRepository : IAddressRepository
    {
        private readonly Nop.Services.Common.IAddressService _addressService;
        public AddressRepository(Nop.Services.Common.IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<Core.Domain.Common.Address> GetAddressById(int id)
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
            currentAddress.ZipPostalCode = $"{apiResult.Zip}-{apiResult.Zip4}";

            var isValid = await _addressService.IsAddressValidAsync(currentAddress);

            if (!isValid)
            {
                return;
            }

            await _addressService.UpdateAddressAsync(currentAddress);
        }
    }
}
