using System.Linq;
using ttManager.Data.data;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.Data
{
    class SettingsHelper
    {
        public static void SaveSetting(Setting setting)
        {
            var oldSetting = GetSetting(setting.Key);

            if (oldSetting != null)
            {
                setting.Id = oldSetting.Id;
                SettingData.Update(setting);
            } else
            {
                SettingData.Create(setting);
            }
        }

        public static Setting GetSetting(string key)
        {
            var filterObject = new FilterObject()
            {
                Column = "Key",
                Value = key
            };

            return SettingData.Get(filterObject).First();
        }

        public static Setting GetSetting(int id)
        {
            return SettingData.Get(id);
        }
    }
}
