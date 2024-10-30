using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Services.Plugins;
using Nop.Services.Tax;

namespace Nop.Plugin.Tax.CustomRules
{
    public class CustomTaxRule : BasePlugin, ITaxProvider
    {
        private readonly IAddressService _addressService;
        public CustomTaxRule(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<TaxRateResult> GetTaxRateAsync(TaxRateRequest taxRateRequest)
        {
            //var address = await _addressService.GetAddressInfoAsync("3408 nw pink hill circle","blue springs, mo 64015");
            await _addressService.SaveAddressDetailsAsync();

            var taxRate = new TaxRateResult();
            taxRate.TaxRate = .08m;
            return taxRate;
        }

        public async Task<TaxTotalResult> GetTaxTotalAsync(TaxTotalRequest taxTotalRequest)
        {
            var taxRateResult = new TaxTotalResult
            {
                TaxTotal = 999.99m
            };

            return taxRateResult;
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
