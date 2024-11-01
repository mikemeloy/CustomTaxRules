using Nop.Plugin.Tax.CustomRules.Data;

namespace Nop.Plugin.Tax.CustomRules.Interfaces;
public interface IAddressVerificationRepository
{
    Task<AddressVerificationDetail> GetAsync(string street, string cityStateZip);
    Task<AddressVerificationDetail> InsertAsync(IAddressResponse apiResult);
}

