using Nop.Plugin.Tax.CustomRules.Models;
using Nop.Plugin.Widgets.ItemDiscount.Models;

namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface ICustomTaxRulesSettingsService
    {
        Task SaveSettingsAsync(CustomTaxRuleSettings settings);
        Task<ConfigurationModel> GetCurrentSettingsAsync();
        Task DeleteAllSettingsAsync();
    }
}
