using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNews.Utils
{
    public static class Constants
    {
        public static class DateTimeFormats
        {
            public const string StandardFullFormat = "dd/MM/yyyy hh:mm";
        }

        public static class FileLocations
        {
            public const string JsonFileLocation = @"C:\dev\WebNews\Json Data\data.json";
        }

        public static class AppSettingsNames
        {
            public const string GoogleMapsApiKeyName = "GoogleMapsApiKey";  
        }
    }
}