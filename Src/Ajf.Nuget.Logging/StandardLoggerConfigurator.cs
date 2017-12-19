using System;
using Serilog;
using Serilog.Configuration;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerConfigurator
    {
        public static ILogger GetEnrichedLogger()
        {
            return GetLoggerConfig()
                .CreateLogger();
        }

        public static LoggerConfiguration GetLoggerConfig()
        {
            var settings = new SettingsFromConfigFile();

            return new LoggerConfiguration()
                .MinimumLevel.Is(settings.LoggingLevel)
                .Enrich.WithMachineName()
                .Enrich.WithProperty("ReleaseNumber", settings.ReleaseNumber)
                .Enrich.WithProperty("Environment", settings.Environment)
                .Enrich.WithProperty("SuiteName", settings.SuiteName)
                .Enrich.WithProperty("ComponentName", settings.ComponentName)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(settings.FileName)
                .WriteTo.Elasticsearch(settings.ElasticsearchSinkOptions);
        }
    }
}