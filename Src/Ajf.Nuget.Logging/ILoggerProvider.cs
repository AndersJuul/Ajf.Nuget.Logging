using Serilog;

namespace Ajf.Nuget.Logging
{
    public interface ILoggerProvider
    {
        ILogger GetLogger();
    }
}