using Nop.Plugin.Tax.CustomRules.Models;

namespace Nop.Plugin.Tax.CustomRules;

internal static class CustomTaxRuleDefaults
{
    public static int UnitedStatesCountryCode => 237;
    public static int BaseTimeToLive = 30;
    public static decimal BaseTaxRate = 8.0m;
    public static string AddressVerifyEndpoint = "https://www.yaddress.net/api/Address";
    public static List<TaxExceptions> TaxExceptions = new()
    {
        new()
        {
            Min = 5000,
            PostalCode = "33770",
            TaxRate = 8.75m
        }
    };
}

