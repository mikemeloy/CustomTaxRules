using Nop.Data;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Extensions;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Repository;

public class AddressVerificationRepository : IAddressVerificationRepository
{
    private readonly IRepository<AddressVerificationDetail> _addressLookupRepository;

    public AddressVerificationRepository(IRepository<AddressVerificationDetail> addressLookupRepository)
    {
        _addressLookupRepository = addressLookupRepository;
    }
    public async Task<AddressVerificationDetail> GetAsync(string street, string postalCode)
    {
        var query = await _addressLookupRepository
            .Table
            .FirstOrDefaultAsync(avd => avd.AddressLine1 == street);

        return query;
    }
    public async Task<AddressVerificationDetail> InsertAsync(IAddressResponse apiResult)
    {
        var entity = apiResult.ToEntity();
        try
        {
            await _addressLookupRepository.InsertAsync(entity);
        }
        catch (Exception e)
        {

            throw;
        }

        return entity;
    }
}

