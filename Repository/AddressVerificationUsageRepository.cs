using Nop.Core;
using Nop.Data;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Repository;

internal class AddressVerificationUsageRepository : IAddressVerificationUsageRepository
{
    private readonly IRepository<AddressLookupUsageStatistic> _addressVerificationUsageRepository;
    private readonly IStoreContext _storeContext;
    private readonly ILogging _log;

    public AddressVerificationUsageRepository(IStoreContext storeContext, IRepository<AddressLookupUsageStatistic> addressVerificationUsageRepository, ILogging log)
    {
        _storeContext = storeContext;
        _addressVerificationUsageRepository = addressVerificationUsageRepository;
        _log = log;
    }
    public async Task UpdateUsageStatisticsAsync(bool success)
    {
        var store = await _storeContext.GetCurrentStoreAsync();
        var stats = await _addressVerificationUsageRepository.Table.FirstOrDefaultAsync(r => r.StoreId == store.Id);
        var isNull = stats is null;

        if (isNull)
        {
            var newRecord = new AddressLookupUsageStatistic
            {
                StoreId = store.Id,
                Calls = 1,
                Success = 1,
            };

            try
            {
                await _addressVerificationUsageRepository.InsertAsync(newRecord);
            }
            catch (Exception e)
            {
                _log.LogError("Failed to insert usage log", e);
            }
            return;
        }

        stats.Calls++;
        if (success)
        {
            stats.Success++;
        }
        try
        {
            await _addressVerificationUsageRepository.UpdateAsync(stats);

        }
        catch (Exception e)
        {

            _log.LogError("Failed to update usage log", e);
        }
    }
}

