using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Services.Logging;

namespace Nop.Plugin.Tax.CustomRules.Infrastructure;

public class Log : ILogging
{
    private readonly ILogger _logger;
    public Log(ILogger logger)
    {
        _logger = logger;
    }

    public void LogError(string error, Exception e)
    {
        _logger.ErrorAsync($"CustomTaxRules Plugin: {error}", e);
    }

    public void LogWarning(string warning)
    {
        _logger.WarningAsync($"CustomTaxRules Plugin: {warning}");
    }
}

