using System;
using System.Configuration;

namespace Ajf.Nuget.Logging
{
    public class ServiceSettingsFromConfigFile : SettingsFromConfigFile
    {
        public ServiceSettingsFromConfigFile()
        {
            Description = ConfigurationManager.AppSettings["Description"];
            DisplayName = ConfigurationManager.AppSettings["DisplayName"];
            ServiceName = ConfigurationManager.AppSettings["ServiceName"];
            RunAsUserName = ConfigurationManager.AppSettings["RunAsUserName"];
            RunAsPassword = ConfigurationManager.AppSettings["RunAsPassword"];

            if (string.IsNullOrEmpty(RunAsUserName))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(RunAsUserName));
            if (string.IsNullOrEmpty(RunAsPassword))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(RunAsPassword));
            if (string.IsNullOrEmpty(Description))
                Description = $"{SuiteName}.{ComponentName}";
            if (string.IsNullOrEmpty(DisplayName))
                DisplayName = $"{SuiteName}.{ComponentName}";
            if (string.IsNullOrEmpty(ServiceName))
                ServiceName = $"{SuiteName}.{ComponentName}";

            Description += ". " + ReleaseNumber;
        }

        public string RunAsPassword { get; set; }

        public string RunAsUserName { get; set; }

        public string ServiceName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}