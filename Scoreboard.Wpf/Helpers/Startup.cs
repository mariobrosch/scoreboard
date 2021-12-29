using Newtonsoft.Json;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Migrations;
using Scoreboard.DataCore.Settings;
using System.Collections.Generic;
using System.IO;

namespace Scoreboard.Wpf.Helpers
{
    internal class Startup
    {
        internal static void Perform()
        {
            Logic.WriteSettings(GetLocalSettings());

            string language = SettingsHelper.GetSettingByKey("Language")?.Value;
            if (language == null)
            {
                language = "Dutch";
            }
            WpfHelper.ChangeLanguage(language);

            Handler migration = new();
            migration.StartMigrations();
        }

        private static List<Model> GetLocalSettings()
        {
            List<Model> settings = new();
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(".\\scoreboard.json"));
            foreach (KeyValuePair<string, string> kv in dict)
            {
                Model setting = new()
                {
                    Key = kv.Key,
                    Value = kv.Value
                };
                settings.Add(setting);
            }
            return settings;
        }
    }
}
