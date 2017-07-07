using System;
using Serilog;
using Serilog.Core.Enrichers;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerConfigurator
    {
        private static IDisposable LogContext { get; set; }

        public static void SetLogger()
        {
            var settings = new SettingsFromConfigFile();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(settings.FileName)
                .WriteTo.Elasticsearch(settings.ElasticsearchSinkOptions)
                .CreateLogger();

            // LogContext is 'remembered' because the properties are applied until this object is recycled.
            LogContext = Serilog.Context.LogContext.Push(new PropertyEnricher("Environment", settings.Environment),
                new PropertyEnricher("SuiteName", settings.SuiteName),
                new PropertyEnricher("ComponentName", settings.ComponentName),
                new PropertyEnricher("ReleaseNumber", settings.ReleaseNumber));
        }
    }
}