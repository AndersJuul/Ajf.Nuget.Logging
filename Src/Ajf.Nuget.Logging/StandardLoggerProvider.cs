using System;
using System.Configuration;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerProvider
    {
        private static ILogger _configuredLogger;
        public static ILogger GetLogger()
        {
            if(_configuredLogger==null)
                _configuredLogger = new LoggerConfiguration()
                .WriteTo.RollingFile(ConfigurationManager.AppSettings["RollingFile"])
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(ConfigurationManager.AppSettings["EsLoggingUrl"])))
                .CreateLogger();

            return _configuredLogger;
        }
    }
}