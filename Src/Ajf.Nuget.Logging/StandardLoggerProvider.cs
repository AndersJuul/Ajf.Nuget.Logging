using Serilog;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerProvider 
    {
        public static ILogger GetLogger()
        {
            return Log.Logger;
        }
    }
}