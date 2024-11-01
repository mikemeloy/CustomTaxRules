using Nop.Core;
using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Plugin.Tax.CustomRules.Models;
using Nop.Plugin.Widgets.ItemDiscount.Models;
using Nop.Services.Configuration;

namespace Nop.Plugin.Tax.CustomRules.Services;
public class SettingService : ICustomTaxRulesSettingsService
{
    private readonly ISettingService _settingService;
    private readonly IStoreContext _storeContext;

    public SettingService(ISettingService settingService, IStoreContext storeContext)
    {
        _settingService = settingService;
        _storeContext = storeContext;
    }
    public async Task<CustomTaxRuleSettings> GetSystemSettingsAsync()
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var settings = await _settingService.LoadSettingAsync<CustomTaxRuleSettings>(storeScope);

        return settings;
    }
    public async Task SaveSettingsAsync(CustomTaxRuleSettings settings)
    {
        await _settingService.SaveSettingAsync(settings);
    }
    public async Task DeleteAllSettingsAsync()
    {
        await _settingService.DeleteSettingAsync<CustomTaxRuleSettings>();
    }
    public async Task<ConfigurationModel> GetCurrentSettingsAsync()
    {
        var settings = await LoadCurrentSettingsAsync();

        return new ConfigurationModel
        {
            Endpoint = settings.Endpoint,
            TimeToLive = settings.TimeToLive,
        };
    }
    private async Task<CustomTaxRuleSettings> LoadCurrentSettingsAsync()
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var settings = await _settingService.LoadSettingAsync<CustomTaxRuleSettings>(storeScope);

        return settings;
    }
}

