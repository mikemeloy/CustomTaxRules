namespace Nop.Plugin.Tax.CustomRules.Extensions;

internal static class DecimalExtensions
{
    internal static decimal ToDecimal(this decimal source) => source / 100;
}

