using Nop.Core.Domain.Common;
using Nop.Plugin.Tax.CustomRules.Data;

namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface IAddressService
    {
        Task<AddressVerificationDetail> GetAddressInfoAsync(string street, string postalCode, int? addressId);
        Task<Address> GetAddressById(int? id);
    }
}
