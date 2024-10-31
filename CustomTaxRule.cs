using Nop.Plugin.Tax.CustomRules.Extensions;
using Nop.Plugin.Tax.CustomRules.Factories;
using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Services.Orders;
using Nop.Services.Plugins;
using Nop.Services.Tax;

namespace Nop.Plugin.Tax.CustomRules
{
    public class CustomTaxRule : BasePlugin, ITaxProvider
    {
        private readonly IAddressService _addressService;
        IShoppingCartService _shoppingCartService;
        public CustomTaxRule(IAddressService addressService, IShoppingCartService shoppingCartService)
        {
            _addressService = addressService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<TaxRateResult> GetTaxRateAsync(TaxRateRequest taxRateRequest)
        {
            var address = await _addressService
                                    .GetAddressInfoAsync(
                                        street: taxRateRequest.GetStreet(),
                                        postalCode: taxRateRequest.GetPostalCode(),
                                        addressId: taxRateRequest.GetAddressId()
                                    );

            var taxRate = TaxRateLookup
                            .Init()
                            .AddAddress(address)
                            .Generate();

            return taxRate;
        }

        public async Task<TaxTotalResult> GetTaxTotalAsync(TaxTotalRequest taxTotalRequest)
        {
            var shippingAddress = await _addressService.GetAddressById(taxTotalRequest.GetShippingId());
            var verifiedAddress = await _addressService
                                            .GetAddressInfoAsync(
                                                street: shippingAddress.Address1,
                                                postalCode: shippingAddress.ZipPostalCode,
                                                addressId: shippingAddress.Id
                                            );

            var taxTotalResult = await TaxTotalLookup
                                        .Init(_shoppingCartService)
                                        .AddCartItems(taxTotalRequest.ShoppingCart)
                                        .AddShippingAddress(verifiedAddress)
                                        .GenerateAsync();

            return taxTotalResult;
        }
        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            await base.InstallAsync();
        }
        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }
    }
}
