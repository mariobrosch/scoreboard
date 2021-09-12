using Newtonsoft.Json;
using Scoreboard.Wpf.Resources.Lang;
using System;
using System.Collections.Generic;
using Scoreboard.DataCore.Settings;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows;

namespace Scoreboard.Wpf
{
    internal static class WpfHelper
    {
        /// <summary>
        /// Play a sound through speakers
        /// </summary>
        /// <param name="soundType"></param>
        internal static void PlaySound(SoundTypes soundType)
        {
            string audioFile = "";
            switch (soundType)
            {
                case SoundTypes.Applause:
                    audioFile = Path.Combine("resources", "Applause.wav");
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(audioFile) && File.Exists(audioFile))
            {
                SoundPlayer player = new(audioFile);
                player.Play();
            }
        }

  

        /// <summary>
        /// Write the json files to the backup location, does not create the backuplocation. If no backuplocation has been set the backup is not executed
        /// </summary>
        internal static void WriteToBackupLocation()
        {
            string backupLocation = Logic.GetSetting("backupLocation");
            string localStoragePath = Logic.GetSetting("localStoragePath");
            string backupDrive = Logic.GetSetting("backupDrive");

            backupLocation = backupLocation.Replace("[computername]", Environment.MachineName);

            if (Directory.Exists(backupDrive))
            {
                if (!Directory.Exists(backupLocation))
                {
                    _ = Directory.CreateDirectory(backupLocation);
                }

                foreach (string file in Directory.GetFiles(localStoragePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(file, file.Replace(localStoragePath, backupLocation), true);
                }
            }
        }

        internal static void ChangeLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = language switch
            {
                "English" => new CultureInfo("en-US"),
                _ => new CultureInfo("nl-NL"),
            };
            LanguageValues.Clear();
        }

        internal static string GetCurrentLanguage()
        {
            return Thread.CurrentThread.CurrentUICulture.ToString();
        }

        /// <summary>
        /// Get resourcetext by key for the set culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns>String of the translated text</returns>
        internal static string GetResourceText(string key)
        {
            if (LanguageValues.Count == 0)
            {
                string languagePath = Path.Combine(".", "Resources", "Lang", GetCurrentLanguage() + ".json");
                Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(languagePath));
                foreach (KeyValuePair<string, string> kv in dict)
                {
                    Text setting = new()
                    {
                        Key = kv.Key,
                        Value = kv.Value
                    };
                    LanguageValues.Add(setting);
                }
            }

            return LanguageValues.FirstOrDefault(l => l.Key == key).Value;
        }

        internal static Uri GetResourceFile(string windowName)
        {
            return new Uri("..\\Resources\\Lang\\Windows\\" + windowName + "." + GetCurrentLanguage() + ".xaml", UriKind.Relative);
        }

        internal static void SetLanguageResourceDictionary(FrameworkElement element, string windowName)
        {
            ResourceDictionary languageDictionary = new();
            languageDictionary.Source = WpfHelper.GetResourceFile(windowName);
            int langDictId = -1;
            for (int i = 0; i < element.Resources.MergedDictionaries.Count; i++)
            {
                ResourceDictionary md = element.Resources.MergedDictionaries[i];
                if (md.Contains("ResourceDictionaryName"))
                {
                    if (md["ResourceDictionaryName"].ToString().StartsWith("Loc-"))
                    {
                        langDictId = i;
                        break;
                    }
                }
            }
            if (langDictId == -1)
            {
                element.Resources.MergedDictionaries.Add(languageDictionary);
            }
            else
            {
                element.Resources.MergedDictionaries[langDictId] = languageDictionary;
            }
        }

        private static readonly List<Text> LanguageValues = new();
    }
}
