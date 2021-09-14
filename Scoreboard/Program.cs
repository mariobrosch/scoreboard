using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Migrations;
using Scoreboard.forms;

namespace Scoreboard
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string language = SettingsHelper.GetSettingByKey("Language")?.Value;
            if (language == null)
            {
                language = "Dutch";
            }

            switch (language)
            {
                case "Dutch":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                    break;
                case "English":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                // case "Dutch":
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                    break;

            }

            Handler migration = new Handler();
            migration.StartMigrations();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
