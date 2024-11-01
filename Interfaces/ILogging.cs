namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface ILogging
    {
        void LogError(string error, Exception e);
        void LogWarning(string warning);
    }
}
