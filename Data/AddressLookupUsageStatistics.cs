using Nop.Core;

namespace Nop.Plugin.Tax.CustomRules.Data;

public class AddressLookupUsageStatistic : BaseEntity
{
    public int StoreId { get; set; }
    public int Calls { get; set; }
    public int Success { get; set; }  
}

