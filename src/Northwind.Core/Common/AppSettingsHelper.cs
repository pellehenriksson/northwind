using System;
using System.Configuration;

namespace Northwind.Core.Common
{
    public static class AppSettingsHelper
    {
        public static T GetValue<T>(string key, T defaultValue)
        {
            return !HasValue(key) ? defaultValue : GetValue<T>(key);
        }

        public static T GetValue<T>(string key)
        {
            if (HasValue(key))
            {
                var value = ConfigurationManager.AppSettings[key];
                var result = Convert.ChangeType(value, typeof(T));

                return (T)result;
            }

            throw new Exception(string.Format("The key: {0} was not found in appsettings", key));
        }

        public static bool HasValue(string key)
        {
            return ConfigurationManager.AppSettings[key] != null;
        }
    }
}
