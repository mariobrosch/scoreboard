using Microsoft.Win32;
using Scoreboard.DataCore.Data;
using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.Wpf.Helpers;
using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows;

namespace Scoreboard.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            _ = new Startup();
            Startup.Perform();

            SettingsHelper.CreateDefaultSettings();
            InitializeComponent();
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            FilterObject filter = new()
            {
                Column = "WinnerId",
                Value = "ISNULL"
            };
            System.Collections.Generic.List<DataCore.Models.Match> matchesWithoutWinner = MatchData.Get(filter);
            System.Collections.Generic.List<DataCore.Models.Match> matchesWitoutWinnerLastWeek = matchesWithoutWinner.Where(m => m.MatchDateParsed > DateTime.Now.AddDays(-7)).ToList();

            if (matchesWithoutWinner.Count == 0)
            {
                if (MessageBox.Show(WpfHelper.GetResourceText("NoUnfinishedMatches"), WpfHelper.GetResourceText("NoMatchesFound"), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (!CheckMatchCanStart())
                    {
                        return;
                    }

                    Hide();
                    Windows.CreateMatch frmCreateMatch = new();
                    _ = frmCreateMatch.ShowDialog();
                    Show();
                }
                return;
            }

            if (matchesWitoutWinnerLastWeek.Count == 1)
            {
                DataCore.Models.Match foundMatch = matchesWithoutWinner.First();
                DataCore.Models.MatchSummary matchSummary = MatchHelper.GetMatchSummary(foundMatch);

                string text = WpfHelper.GetResourceText("recentMatch1") + " '" + matchSummary.TeamLeft + "' " + WpfHelper.GetResourceText("and") + " '" + matchSummary.TeamRight + "' " + WpfHelper.GetResourceText("withMatchType") + " " + matchSummary.MatchType.Type + "\r\n\r\n";
                text += WpfHelper.GetResourceText("thereAre") + " " + matchSummary.Sets.Count.ToString() + " " + WpfHelper.GetResourceText("setsPlayed") + ".\r\n";
                text += "\r\n " + WpfHelper.GetResourceText("standings") + " " + matchSummary.Standings + "\r\n";
                text += "\r\n" + WpfHelper.GetResourceText("continueMatch");

                if (MessageBox.Show(text, WpfHelper.GetResourceText("continueMatch"), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Hide();
                    Windows.PlayMatch playMatch = new(foundMatch);
                    _ = playMatch.ShowDialog();
                    Show();
                }
            }

            // Now we are at a place where we always have multiple matches unfinished found.
            Windows.ContinueMatchSelection continueMatchSelection = new();
            _ = continueMatchSelection.ShowDialog();
        }

        private void BtnNewMatch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckMatchCanStart())
            {
                return;
            }

            Hide();
            Windows.CreateMatch frmCreateMatch = new();
            _ = frmCreateMatch.ShowDialog();
            Show();
        }

        private void BtnMatchTypes_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Windows.MatchTypes frmMatchTypes = new();
            _ = frmMatchTypes.ShowDialog();
            Show();
        }

        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Windows.Players playersWindow = new();
            _ = playersWindow.ShowDialog();
            Show();
        }

        private static bool CheckMatchCanStart()
        {
            System.Collections.Generic.List<DataCore.Models.MatchType> matchTypes = MatchTypeData.Get();
            if (matchTypes.Count == 0)
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("noMatchTypesFound"));
                return false;
            }

            System.Collections.Generic.List<DataCore.Models.Player> players = PlayerData.Get();
            if (players.Count < 2)
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("notEnoughPlayers"));
                return false;
            }

            return true;
        }

        private void DataExporterenToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string dataLocation = ConfigurationManager.AppSettings["dataLocation"];
            string localStoragePath = ConfigurationManager.AppSettings["localStoragePath"];
            if (dataLocation != "local")
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("exportOnlyLocalstorage"));
                return;
            }

            if (Directory.GetFiles(localStoragePath).Length == 0)
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("NoDataFound"));
                return;
            }

            SaveFileDialog sfdZipfile = new()
            {
                Filter = "Zip|*.zip",
                Title = WpfHelper.GetResourceText("SaveZip")
            };

            if (sfdZipfile.ShowDialog() != true)
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("SaveCanceled"));
                WpfHelper.WriteToBackupLocation();
            }
            else
            {
                ZipFile.CreateFromDirectory(localStoragePath, sfdZipfile.FileName);
            }
        }

        private void VerderSpelenToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BtnContinue_Click(sender, e);
        }

        private void NieuwSpelToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BtnNewMatch_Click(sender, e);
        }

        private void SpeltypesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BtnMatchTypes_Click(sender, e);
        }

        private void SpelersToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BtnPlayers_Click(sender, e);
        }

        private void SinglePlayerToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Windows.CreateSingleMatch createSingleForm = new();
            _ = createSingleForm.ShowDialog();
            Show();
        }

        private void SettingsToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Windows.Settings settingsForm = new();
            _ = settingsForm.ShowDialog();
            Show();
        }
    }
}
