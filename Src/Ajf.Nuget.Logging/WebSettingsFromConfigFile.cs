namespace Ajf.Nuget.Logging
{
    public class WebSettingsFromConfigFile : SettingsFromConfigFile
    {
        public WebSettingsFromConfigFile()
        {
            //Description = ConfigurationManager.AppSettings["Description"];
            //DisplayName = ConfigurationManager.AppSettings["DisplayName"];
            //ServiceName = ConfigurationManager.AppSettings["ServiceName"];

            //if (string.IsNullOrEmpty(Description))
            //    Description = $"{SuiteName}.{ComponentName}.{ReleaseNumber}";
            //if (string.IsNullOrEmpty(DisplayName))
            //    DisplayName = $"{SuiteName}.{ComponentName}";
            //if (string.IsNullOrEmpty(ServiceName))
            //    ServiceName = $"{SuiteName}.{ComponentName}";
        }

        //public string ServiceName { get; set; }

        //public string DisplayName { get; set; }

        //public string Description { get; set; }
    }
}