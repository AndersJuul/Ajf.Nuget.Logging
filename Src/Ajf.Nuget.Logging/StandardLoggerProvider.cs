using System;
using System.Configuration;
using Serilog;
using Serilog.Core.Enrichers;
using Serilog.Sinks.Elasticsearch;

namespace Ajf.Nuget.Logging
{
    public class StandardLoggerProvider
    {
        private static IDisposable LogContext { get; set; }

        public static void SetLogger()
        {
            var fileName = ConfigurationManager.AppSettings["LogFileDirectory"] +
                           ConfigurationManager.AppSettings["SuiteName"] + "." +
                           ConfigurationManager.AppSettings["ComponentName"] + ".log";

            var esLoggingUrl = ConfigurationManager.AppSettings["EsLoggingUrl"];

            var esLoggingUri = new Uri(esLoggingUrl);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(fileName)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(esLoggingUri))
                .CreateLogger();

            LogContext = Serilog.Context.LogContext.Push(
                new PropertyEnricher("Environment", ConfigurationManager.AppSettings["Environment"]));
        }
    }
}