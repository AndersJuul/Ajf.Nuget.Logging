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
            if (_configuredLogger == null)
            {
                var fileName = ConfigurationManager.AppSettings["LogFileDirectory"] +
                                 ConfigurationManager.AppSettings["SuiteName"] + "." +
                                 ConfigurationManager.AppSettings["ComponentName"] + ".log";

                var esLoggingUrl = ConfigurationManager.AppSettings["EsLoggingUrl"];

                var esLoggingUri = new Uri(esLoggingUrl);

                _configuredLogger = new LoggerConfiguration()
                    .WriteTo.RollingFile(fileName)
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(esLoggingUri))
                    .CreateLogger();
            }

            return _configuredLogger;
        }
    }
}