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

            if (string.IsNullOrEmpty(Description))
                Description = $"{SuiteName}.{ComponentName}";
            if (string.IsNullOrEmpty(DisplayName))
                DisplayName = $"{SuiteName}.{ComponentName}";
            if (string.IsNullOrEmpty(ServiceName))
                ServiceName = $"{SuiteName}.{ComponentName}";

            Description += ". " + ReleaseNumber;
        }

        public string ServiceName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}