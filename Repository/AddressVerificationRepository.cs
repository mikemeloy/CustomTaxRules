using Nop.Data;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Extensions;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Repository;

public class AddressVerificationRepository : IAddressVerificationRepository
{
    private readonly IRepository<AddressVerificationDetail> _addressLookupRepository;
    private readonly ILogging _log;

    public AddressVerificationRepository(IRepository<AddressVerificationDetail> addressLookupRepository, ILogging log)
    {
        _addressLookupRepository = addressLookupRepository;
        _log = log;
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
            _log.LogError("Failed to insert an address verification record", e);
        }

        return entity;
    }
}

