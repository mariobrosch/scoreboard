using System;
using System.Configuration;
using System.IO;
using System.Media;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace Scoreboard
{
    static class FormsHelper
    {
        internal static void PlaySound(SoundTypes st)
        {
            var audioFile = "";
            switch (st)
            {
                case SoundTypes.Applause:
                    audioFile = Path.Combine("resources", "Applause.wav");
                    break;
            }

            if (!string.IsNullOrEmpty(audioFile) && File.Exists(audioFile))
            {
                SoundPlayer player = new SoundPlayer(audioFile);
                player.Play();
            }
        }

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
                    Directory.CreateDirectory(backupLocation);
                }

                foreach (string file in Directory.GetFiles(localStoragePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(file, file.Replace(localStoragePath, backupLocation), true);
                }
            }
        }

        /// <summary>
        /// Get resources by key for the set culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns>String of the translated text</returns>
        internal static string GetResourceText(string key)
        {
            var resourceManager = new ResourceManager(typeof(FormsHelper).Namespace + ".Properties.Resource", Assembly.GetExecutingAssembly());
            return resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
        }
    }
}
