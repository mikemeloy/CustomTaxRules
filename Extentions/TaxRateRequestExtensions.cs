using Nop.Services.Tax;

namespace Nop.Plugin.Tax.CustomRules.Extensions;

public static class TaxRateRequestExtensions
{
    public static string GetStreet(this TaxRateRequest source) => source?.Address?.Address1 ?? "";
    public static string GetPostalCode(this TaxRateRequest source) => source?.Address?.ZipPostalCode ?? "";
    public static int? GetAddressId(this TaxRateRequest source) => source?.Address?.Id;
}

