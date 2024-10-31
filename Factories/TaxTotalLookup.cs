using Nop.Core.Domain.Orders;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Factories.Models;
using Nop.Services.Orders;
using Nop.Services.Tax;

namespace Nop.Plugin.Tax.CustomRules.Factories
{

    public class TaxTotalLookup
    {
        private readonly IShoppingCartService _shoppingCartService;
        private IList<ShoppingCartItem> _shoppingCart;
        private AddressVerificationDetail _shippingAddress;

        public TaxTotalLookup(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        internal static TaxTotalLookup Init(IShoppingCartService shoppingCartService) => new(shoppingCartService);

        internal TaxTotalLookup AddCartItems(IList<ShoppingCartItem> shoppingCart)
        {
            _shoppingCart = shoppingCart;
            return this;
        }

        internal TaxTotalLookup AddShippingAddress(AddressVerificationDetail shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        internal async Task<TaxTotalResult> GenerateAsync()
        {
            var cartItemsWithPrice = await GetCartItemPricesAsync();
            var cartSubTotal = cartItemsWithPrice.Sum(item => item.Price - item.Discount);
            var cartTax = cartSubTotal * (_shippingAddress.SalesTaxRate / 100);

            return new()
            {
                TaxTotal = cartTax
            };
        }

        private async Task<CartItem[]> GetCartItemPricesAsync()
        {
            return await Task.WhenAll(_shoppingCart.Select(async item =>
            {
                var (price, discount, _) = await _shoppingCartService.GetUnitPriceAsync(item, includeDiscounts: true);

                return new CartItem()
                {
                    ProductId = item.ProductId,
                    Price = price,
                    Discount = discount
                };
            }));
        }
    }
}
