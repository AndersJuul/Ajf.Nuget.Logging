using Serilog;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerConfigurator
    {
        public static ILogger GetEnrichedLogger()
        {
            var settings = new SettingsFromConfigFile();

            return new LoggerConfiguration()
                .Enrich.WithProperty("ReleaseNumber", settings.ReleaseNumber)
                .Enrich.WithProperty("Environment", settings.Environment)
                .Enrich.WithProperty("SuiteName", settings.SuiteName)
                .Enrich.WithProperty("ComponentName", settings.ComponentName)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(settings.FileName)
                .WriteTo.Elasticsearch(settings.ElasticsearchSinkOptions)
                .CreateLogger();
        }
    }
}