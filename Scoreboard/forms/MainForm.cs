using Ionic.Zip;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.DataCore.Data;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Data.Requests;

namespace Scoreboard.forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            SettingsHelper.CreateDefaultSettings();

            InitializeComponent();
        }

        private void BtnPlayers_Click(object sender, EventArgs e)
        {
            FrmPlayers frmPlayers = new FrmPlayers();
            _ = frmPlayers.ShowDialog();
        }

        private void BtnMatchTypes_Click(object sender, EventArgs e)
        {
            FrmMatchTypes frmMatchTypes = new FrmMatchTypes();
            _ = frmMatchTypes.ShowDialog();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            FilterObject filter = new FilterObject
            {
                Column = "WinnerId",
                Value = "ISNULL"
            };
            System.Collections.Generic.List<DataCore.Models.Match> matchesWithoutWinner = MatchData.Get(filter);
            System.Collections.Generic.List<DataCore.Models.Match> matchesWitoutWinnerLastWeek = matchesWithoutWinner.Where(m => m.MatchDateParsed > DateTime.Now.AddDays(-7)).ToList();

            if (matchesWithoutWinner.Count == 0)
            {
                if (MessageBox.Show(FormsHelper.GetResourceText("NoUnfinishedMatches"), FormsHelper.GetResourceText("NoMatchesFound"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!CheckMatchCanStart())
                    {
                        return;
                    }

                    Hide();
                    CreateMatch frmCreateMatch = new CreateMatch();
                    _ = frmCreateMatch.ShowDialog();
                    Show();
                }
                return;
            }

            if (matchesWitoutWinnerLastWeek.Count == 1)
            {
                DataCore.Models.Match foundMatch = matchesWithoutWinner.First();
                DataCore.Models.MatchSummary matchSummary = MatchHelper.GetMatchSummary(foundMatch);

                string text = FormsHelper.GetResourceText("recentMatch1") + " '" + matchSummary.TeamLeft + "' " + FormsHelper.GetResourceText("and") + " '" + matchSummary.TeamRight + "' " + FormsHelper.GetResourceText("withMatchType") + " " + matchSummary.MatchType.Type + "\r\n\r\n";
                text += FormsHelper.GetResourceText("thereAre") + " " + matchSummary.Sets.Count.ToString() + " " + FormsHelper.GetResourceText("setsPlayed") + ".\r\n";
                text += "\r\n " + FormsHelper.GetResourceText("standings") + " " + matchSummary.Standings + "\r\n";
                text += "\r\n" + FormsHelper.GetResourceText("continueMatch");

                if (MessageBox.Show(text, FormsHelper.GetResourceText("continueMatch"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Hide();
                    PlayMatch playMatch = new PlayMatch(foundMatch);
                    _ = playMatch.ShowDialog();
                    Show();
                }
            }

            // Now we are at a place where we always have multiple matches unfinished found.
            ContinueMatchSelection continueMatchSelection = new ContinueMatchSelection();
            _ = continueMatchSelection.ShowDialog();
        }

        private bool CheckMatchCanStart()
        {
            System.Collections.Generic.List<DataCore.Models.MatchType> matchTypes = MatchTypeData.Get();
            if (matchTypes.Count == 0)
            {
                _ = MessageBox.Show(FormsHelper.GetResourceText("noMatchTypesFound"));
                return false;
            }

            System.Collections.Generic.List<DataCore.Models.Player> players = PlayerData.Get();
            if (players.Count < 2)
            {
                _ = MessageBox.Show(FormsHelper.GetResourceText("notEnoughPlayers"));
                return false;
            }

            return true;
        }

        private void BtnNewMatch_Click(object sender, EventArgs e)
        {
            if (!CheckMatchCanStart())
            {
                return;
            }

            Hide();
            CreateMatch frmCreateMatch = new CreateMatch();
            _ = frmCreateMatch.ShowDialog();
            Show();
        }

        private void DataExporterenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dataLocation = ConfigurationManager.AppSettings["dataLocation"];
            string localStoragePath = ConfigurationManager.AppSettings["localStoragePath"];
            if (dataLocation != "local")
            {
                _ = MessageBox.Show(FormsHelper.GetResourceText("exportOnlyLocalstorage"));
                return;
            }

            if (Directory.GetFiles(localStoragePath).Length == 0)
            {
                _ = MessageBox.Show(FormsHelper.GetResourceText("NoDataFound"));
                return;
            }

            sfdZipfile.Filter = "Zip|*.zip";
            sfdZipfile.Title = FormsHelper.GetResourceText("SaveZip");

            DialogResult targetLocation = sfdZipfile.ShowDialog();
            if (DialogResult.OK != targetLocation)
            {
                _ = MessageBox.Show(FormsHelper.GetResourceText("SaveCanceled"));
                FormsHelper.WriteToBackupLocation();
            }
            else
            {
                using (ZipFile zip = new ZipFile())
                {
                    _ = zip.AddDirectory(localStoragePath);
                    zip.Save(sfdZipfile.FileName);
                }
            }
        }

        private void VerderSpelenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnContinue_Click(sender, e);
        }

        private void NieuwSpelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnNewMatch_Click(sender, e);
        }

        private void SpeltypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnMatchTypes_Click(sender, e);
        }

        private void SpelersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnPlayers_Click(sender, e);
        }

        private void SinglePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSinglePlayerMatch createSingleForm = new CreateSinglePlayerMatch();
            Hide();
            _ = createSingleForm.ShowDialog();
            Show();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSettings settingsForm = new FrmSettings();
            Hide();
            _ = settingsForm.ShowDialog();
            Show();
        }
    }
}
