using Newtonsoft.Json;
using Scoreboard.Wpf.Resources.Lang;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;

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
            string backupLocation = ConfigurationManager.AppSettings["backupLocation"];
            string localStoragePath = ConfigurationManager.AppSettings["localStoragePath"];
            string backupDrive = ConfigurationManager.AppSettings["backupDrive"];

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

        /// <summary>
        /// Get resourcetext by key for the set culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns>String of the translated text</returns>
        internal static string GetResourceText(string key)
        {
            if (LanguageValues.Count == 0)
            {
                string languagePath = Path.Combine(".", "Resources", "Lang", Thread.CurrentThread.CurrentUICulture + ".json");
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

        private static readonly List<Text> LanguageValues = new();
    }
}
