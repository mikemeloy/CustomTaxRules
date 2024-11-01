using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Plugin.Tax.CustomRules.Repository;
using Nop.Plugin.Tax.CustomRules.Services;

namespace Nop.Plugin.Tax.CustomRules.Infrastructure;

public class NopStartup : INopStartup
{
    public int Order => 2;

    public void Configure(IApplicationBuilder application) { }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IAddressVerificationRepository, AddressVerificationRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICustomTaxRulesSettingsService, SettingService>();
        services.AddScoped<IAddressVerificationUsageRepository, AddressVerificationUsageRepository>();
        services.AddScoped<ILogging, Log>();
    }
}

