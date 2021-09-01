using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Scoreboard.Data.Helpers;
using Scoreboard.Data.Migrations;

namespace Scoreboard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var language = SettingsHelper.GetSettingByKey("Language")?.Value;
            if (language == null)
            {
                language = "Dutch";
            }

            switch(language)
            {
                case "Dutch":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                    break;
                case "English":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
            }

            var migration = new Handler();
            migration.StartMigrations();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
