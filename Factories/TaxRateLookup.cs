using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Services.Tax;

namespace Nop.Plugin.Tax.CustomRules.Factories;

public class TaxRateLookup
{
    private AddressVerificationDetail _addressDetails;

    private TaxRateLookup() { }
    public static TaxRateLookup Init() => new();
    public TaxRateLookup AddAddress(AddressVerificationDetail details)
    {
        _addressDetails = details;
        return this;
    }
    public TaxRateResult Generate()
    {
        return new TaxRateResult
        {
            TaxRate = _addressDetails.SalesTaxRate
        };
    }
}