using Serilog.Core;
using Serilog.Events;

namespace Ajf.Nuget.Logging
{
    public class SettingsEnricher: ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var settings = new SettingsFromConfigFile();
            propertyFactory.CreateProperty("Environment", settings.Environment);
            propertyFactory.CreateProperty("SuiteName", settings.SuiteName);
            propertyFactory.CreateProperty("ComponentName", settings.ComponentName);
            propertyFactory.CreateProperty("ReleaseNumber", settings.ReleaseNumber);
        }
    }
}