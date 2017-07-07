using System;
using Serilog;
using Serilog.Core.Enrichers;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerConfigurator
    {
        public static ILogger GetLogger()
        {
            var settings = new SettingsFromConfigFile();

            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(settings.FileName)
                .WriteTo.Elasticsearch(settings.ElasticsearchSinkOptions)
                .CreateLogger();
        }

        public static IDisposable GetLogContext()
        {
            var settings = new SettingsFromConfigFile();
            // LogContext is 'remembered' because the properties are applied until this object is recycled.
            var LogContext = Serilog.Context.LogContext.Push(
                new PropertyEnricher("Environment", settings.Environment),
                new PropertyEnricher("SuiteName", settings.SuiteName),
                new PropertyEnricher("ComponentName", settings.ComponentName),
                new PropertyEnricher("ReleaseNumber", settings.ReleaseNumber));

            return LogContext;
        }
    }
}