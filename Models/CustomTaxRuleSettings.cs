using Nop.Core.Configuration;

namespace Nop.Plugin.Tax.CustomRules.Models;

public class CustomTaxRuleSettings : ISettings
{
    public int TimeToLive { get; set; }
    public string Endpoint { get; set; }
    public decimal BaseTaxRate { get; set; }
}

internal class SettingsFactory
{
    private CustomTaxRuleSettings _settings;
    public SettingsFactory()
    {
        _settings = new CustomTaxRuleSettings();
    }
    public SettingsFactory SetTimeToLive(int timeToLive)
    {
        _settings.TimeToLive = timeToLive;
        return this;
    }
    public SettingsFactory SetEndpoint(string endpoint)
    {
        _settings.Endpoint = endpoint;
        return this;
    }
    public SettingsFactory SetBaseTaxRate(decimal baseTaxRate)
    {
        _settings.BaseTaxRate = baseTaxRate;
        return this;
    }
    public CustomTaxRuleSettings Generate() => _settings;
    public static SettingsFactory Init() => new SettingsFactory();
}