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
using System.Windows.Media;

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
            languageDictionary.Source = GetResourceFile(windowName);
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


        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                if (child is not T)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    // If the child's name is set for search
                    if (child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
