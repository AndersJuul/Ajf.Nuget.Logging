using System;
using Serilog;
using Serilog.Core.Enrichers;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerConfigurator
    {
        public static ILogger GetEnrichedLogger()
        {
            var settings = new SettingsFromConfigFile();

            return new LoggerConfiguration()
                .Enrich.With<SettingsEnricher>()
                //.Enrich.FromLogContext()
                .WriteTo.RollingFile(settings.FileName)
                .WriteTo.Elasticsearch(settings.ElasticsearchSinkOptions)
                .CreateLogger();
        }
    }
}