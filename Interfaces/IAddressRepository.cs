using Nop.Core.Domain.Common;

namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface IAddressRepository
    {
        Task UpdateAddressAsync(int? id, IAddressResponse apiResult);
        Task<Address> GetAddressById(int id);
    }
}
