using Serilog;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerProvider : ILoggerProvider
    {
        public ILogger GetLogger()
        {
            return Log.Logger;
        }
    }
}