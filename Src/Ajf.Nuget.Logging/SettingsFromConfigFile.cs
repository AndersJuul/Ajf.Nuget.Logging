using System;
using System.Configuration;
using Serilog.Sinks.Elasticsearch;

namespace Ajf.Nuget.Logging
{
    public class SettingsFromConfigFile
    {
        public SettingsFromConfigFile()
        {
            Environment = ConfigurationManager.AppSettings["Environment"];
            SuiteName = ConfigurationManager.AppSettings["SuiteName"];
            ComponentName = ConfigurationManager.AppSettings["ComponentName"];
            LogFileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            EsLoggingUrl = ConfigurationManager.AppSettings["EsLoggingUrl"];
            ReleaseNumber = ConfigurationManager.AppSettings["ReleaseNumber"];

            FileName = $"{LogFileDirectory}{SuiteName}.{ComponentName}.log";

            EsLoggingUri = new Uri(EsLoggingUrl);
            ElasticsearchSinkOptions = new ElasticsearchSinkOptions(EsLoggingUri);
        }

        public string LogFileDirectory { get; set; }

        public string ReleaseNumber { get; set; }
        public string ComponentName { get; set; }
        public string SuiteName { get; set; }
        public string FileName { get; set; }
        public string EsLoggingUrl { get; set; }
        public Uri EsLoggingUri { get; set; }
        public ElasticsearchSinkOptions ElasticsearchSinkOptions { get; set; }
        public string Environment { get; set; }
    }
}