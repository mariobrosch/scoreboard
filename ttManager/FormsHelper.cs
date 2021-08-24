using System;
using System.Configuration;
using System.IO;
using System.Media;

namespace ttManager
{
    static class FormsHelper
    {
        internal static void PlaySound(SoundTypes st)
        {
            switch (st)
            {
                case SoundTypes.Applause:

                    SoundPlayer player = new SoundPlayer("Applause.wav");
                    player.Play();
                    break;
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
    }
}
