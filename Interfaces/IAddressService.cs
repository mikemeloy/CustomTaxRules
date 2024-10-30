using AddressLookup.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface IAddressService
    {
        Task<IAddressResponse> GetAddressInfoAsync(string addressOne, string addressTwo);
        Task<bool> SaveAddressDetailsAsync();
    }
}
