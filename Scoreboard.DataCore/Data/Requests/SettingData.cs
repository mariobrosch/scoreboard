using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using static Scoreboard.DataCore.Data.Filter;

namespace Scoreboard.DataCore.Data.Requests
{
    public static class SettingData
    {
        private const ModelType tableName = ModelType.Settings;

        public static List<Setting> Get()
        {
            return Get("", "");
        }

        public static Setting Get(int key)
        {
            return Get(key.ToString()).First();
        }

        public static List<Setting> Get(FilterObject filter)
        {
            return Get("", CreateFilter(filter));
        }

        public static List<Setting> Get(string key, string filter = "")
        {
            string settingss = GetData(key, filter);

            return JsonConvert.DeserializeObject<List<Setting>>(settingss);
        }

        private static string GetData(int key, string filter = "")
        {
            return GetData(key.ToString(), filter);
        }

        private static string GetData(string key, string filter = "")
        {
            return RequestHandler.MakeRequest(HttpMethods.GET, tableName, key, filter);
        }

        public static int Delete(string key, string filter = "")
        {
            string numberOfRowsDeleted = RequestHandler.MakeRequest(HttpMethods.DELETE, tableName, key, filter);
            return int.Parse(numberOfRowsDeleted);
        }

        public static Setting Create(Setting settings)
        {
            string data = JsonConvert.SerializeObject(settings);
            string settingsId = RequestHandler.MakeRequest(HttpMethods.POST, tableName, "", "", data);
            string newSettings = GetData(settingsId);
            return JsonConvert.DeserializeObject<List<Setting>>(newSettings).First();
        }

        public static bool Update(Setting settings)
        {
            string data = JsonConvert.SerializeObject(settings);
            return RequestHandler.MakeRequest(HttpMethods.PUT, tableName, settings.Id, "", data) != "0";
        }

        public static bool Update(int settingsId, string property, string value)
        {
            Setting settings = JsonConvert.DeserializeObject<List<Setting>>(GetData(settingsId)).First();
            settings.SetProperty(property, value);
            return Update(settings);
        }

        public static void CreateDefault(string key, string value)
        {
            Setting setting = SettingsHelper.GetSettingByKey(key);
            if (setting == null)
            {
                SettingsHelper.Create(key, value);
            }
        }
    }
}
