using Nop.Plugin.Tax.CustomRules.Factories.Models;

namespace Nop.Plugin.Tax.CustomRules.Extensions;

internal static class CartItemExtensions
{
    internal static decimal Total(this CartItem[] source) => source.Sum(item => item.Price);
}

