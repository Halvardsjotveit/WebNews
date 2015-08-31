using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebNews.Utils
{
    public static class Settings
    {
        public static string GoogleMapsApiKey

        {
            get { return ConfigurationManager.AppSettings[Constants.AppSettingsNames.GoogleMapsApiKeyName]; }
        }
    }
}