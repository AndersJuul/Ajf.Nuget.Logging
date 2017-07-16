using System;
using System.Configuration;

namespace Ajf.Nuget.Logging
{
    public class ServiceSettingsFromConfigFile: SettingsFromConfigFile
    {
        public ServiceSettingsFromConfigFile()
        {
            Description = ConfigurationManager.AppSettings["Description"];
            DisplayName = ConfigurationManager.AppSettings["DisplayName"];
            ServiceName = ConfigurationManager.AppSettings["ServiceName"];

            if (string.IsNullOrEmpty(Description))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(Description));
            if (string.IsNullOrEmpty(DisplayName))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(DisplayName));
            if (string.IsNullOrEmpty(ServiceName))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(ServiceName));
        }

        public string ServiceName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}