namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface IAddressVerificationUsageRepository
    {
        Task UpdateUsageStatisticsAsync(bool success);
    }
}
