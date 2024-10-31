using Nop.Services.Tax;

namespace Nop.Plugin.Tax.CustomRules.Extensions
{
    public static class TaxTotalRequestExtensions
    {
        public static int? GetShippingId(this TaxTotalRequest source) => source?.Customer?.ShippingAddressId;
       
    }
}
