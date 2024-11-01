using Nop.Core;
using Nop.Data;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Repository;

internal class AddressVerificationUsageRepository : IAddressVerificationUsageRepository
{
    private readonly IRepository<AddressLookupUsageStatistic> _addressVerificationUsageRepository;
    private readonly IStoreContext _storeContext;

    public AddressVerificationUsageRepository(IStoreContext storeContext, IRepository<AddressLookupUsageStatistic> addressVerificationUsageRepository)
    {
        _storeContext = storeContext;
        _addressVerificationUsageRepository = addressVerificationUsageRepository;
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
            await _addressVerificationUsageRepository.InsertAsync(newRecord);
            return;
        }

        stats.Calls++;
        if (success)
        {
            stats.Success++;
        }
        await _addressVerificationUsageRepository.UpdateAsync(stats);

    }
}

