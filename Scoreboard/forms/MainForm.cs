using Ionic.Zip;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data.data;
using Scoreboard.Data.data.requests;
using Scoreboard.Data.Helpers;

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
            frmPlayers.ShowDialog();
        }

        private void BtnMatchTypes_Click(object sender, EventArgs e)
        {
            FrmMatchTypes frmMatchTypes = new FrmMatchTypes();
            frmMatchTypes.ShowDialog();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            var filter = new FilterObject
            {
                Column = "WinnerId",
                Value = "ISNULL"
            };
            var matchesWithoutWinner = MatchData.Get(filter);
            var matchesWitoutWinnerLastWeek = matchesWithoutWinner.Where(m => m.MatchDateParsed > DateTime.Now.AddDays(-7)).ToList();

            if (matchesWithoutWinner.Count == 0)
            {
                if (MessageBox.Show(FormsHelper.GetResourceText("NoUnfinishedMatches"), FormsHelper.GetResourceText("NoMatchesFound"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!CheckMatchCanStart())
                    {
                        return;
                    }

                    Hide();
                    var frmCreateMatch = new CreateMatch();
                    frmCreateMatch.ShowDialog();
                    Show();
                }
                return;
            }

            if (matchesWitoutWinnerLastWeek.Count == 1)
            {
                var foundMatch = matchesWithoutWinner.First();
                var matchSummary = MatchHelper.GetMatchSummary(foundMatch);

                var text = FormsHelper.GetResourceText("recentMatch1") + " '" + matchSummary.TeamLeft + "' " + FormsHelper.GetResourceText("and") + " '" + matchSummary.TeamRight + "' " + FormsHelper.GetResourceText("withMatchType") + " " + matchSummary.MatchType.Type + "\r\n\r\n";
                text += FormsHelper.GetResourceText("thereAre") + " " + matchSummary.Sets.Count.ToString() + " " + FormsHelper.GetResourceText("setsPlayed") + ".\r\n";
                text += "\r\n " + FormsHelper.GetResourceText("standings") + " " + matchSummary.Standings + "\r\n";
                text += "\r\n" + FormsHelper.GetResourceText("continueMatch");

                if (MessageBox.Show(text, FormsHelper.GetResourceText("continueMatch"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Hide();
                    PlayMatch playMatch = new PlayMatch(foundMatch);
                    playMatch.ShowDialog();
                    Show();
                }
            }

            // Now we are at a place where we always have multiple matches unfinished found.
            ContinueMatchSelection continueMatchSelection = new ContinueMatchSelection();
            continueMatchSelection.ShowDialog();
        }

        private bool CheckMatchCanStart()
        {
            var matchTypes = MatchTypeData.Get();
            if (matchTypes.Count == 0)
            {
                MessageBox.Show(FormsHelper.GetResourceText("noMatchTypesFound"));
                return false;
            }

            var players = PlayerData.Get();
            if (players.Count < 2)
            {
                MessageBox.Show(FormsHelper.GetResourceText("notEnoughPlayers"));
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
            var frmCreateMatch = new CreateMatch();
            frmCreateMatch.ShowDialog();
            Show();
        }

        private void DataExporterenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dataLocation = ConfigurationManager.AppSettings["dataLocation"];
            string localStoragePath = ConfigurationManager.AppSettings["localStoragePath"];
            if (dataLocation != "local")
            {
                MessageBox.Show(FormsHelper.GetResourceText("exportOnlyLocalstorage"));
                return;
            }

            if (Directory.GetFiles(localStoragePath).Length == 0)
            {
                MessageBox.Show(FormsHelper.GetResourceText("NoDataFound"));
                return;
            }

            sfdZipfile.Filter = "Zip|*.zip";
            sfdZipfile.Title = FormsHelper.GetResourceText("SaveZip");

            var targetLocation = sfdZipfile.ShowDialog();
            if (DialogResult.OK != targetLocation)
            {
                MessageBox.Show(FormsHelper.GetResourceText("SaveCanceled"));
                FormsHelper.WriteToBackupLocation();
            }
            else
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(localStoragePath);
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
            var createSingleForm = new CreateSinglePlayerMatch();
            Hide();
            createSingleForm.ShowDialog();
            Show();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new FrmSettings();
            Hide();
            settingsForm.ShowDialog();
            Show();
        }
    }
}
