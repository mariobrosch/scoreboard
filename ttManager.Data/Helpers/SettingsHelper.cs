using System;
using System.Collections.Generic;
using System.Linq;
using ttManager.Data.data;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.Data.Helpers
{
    public static class SettingsHelper
    {
        public static Setting GetSettingByKey(string key)
        {
            var filterObject = new FilterObject()
            {
                Column = "Key",
                Value = key
            };

            return SettingData.Get(filterObject).FirstOrDefault();
        }

        public static void Create(string key, string value)
        {
            var setting = new Setting()
            {
                Key = key,
                Value = value
            };
            SettingData.Create(setting);
        }

        public static List<Setting> GetDefaultSettings()
        {
            var defaultSettings = new List<Setting>();
            var languageSetting = new Setting()
            {
                Key = "Language",
                Value = "Dutch",
                PossibleValues = "Dutch"
            };
            defaultSettings.Add(languageSetting);

            return defaultSettings;
        }

        public static void CreateDefaultSettings()
        {
            foreach (var setting in GetDefaultSettings())
            {
                SettingData.CreateDefault(setting.Key, setting.Value);
            }
        }
    }
}
