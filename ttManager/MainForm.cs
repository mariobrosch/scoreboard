using Ionic.Zip;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ttManager.Data.data;
using ttManager.Data.data.requests;
using ttManager.Data.Helpers;
using ttManager.forms;

namespace ttManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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
                if (MessageBox.Show("Geen wedstrijden zonder winnaar gevonden, een nieuwe starten?", "Geen open wedstrijd gevonden", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!CheckGameCanStart())
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

                var text = "Eén recente (laatste week) wedstrijd gevonden tussen '" + matchSummary.TeamLeft + "' en '" + matchSummary.TeamRight + "' met als speltype " + matchSummary.MatchType.Type + "\r\n\r\n";
                text += "Er zijn " + matchSummary.Games.Count.ToString() + " games gespeeld.\r\n";
                text += "\r\n Stand is " + matchSummary.Standings + "\r\n";
                text += "\r\nVerder gaan met deze wedstrijd?";

                if (MessageBox.Show(text, "Verder gaan met deze wedstrijd?", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private bool CheckGameCanStart()
        {
            var matchTypes = MatchTypeData.Get();
            if (matchTypes.Count == 0)
            {
                MessageBox.Show("Geen wedstrijd types gevonden, maak er eerst eentje aan voordat een spel gemaakt kan worden.");
                return false;
            }

            var players = PlayerData.Get();
            if (players.Count < 2)
            {
                MessageBox.Show("Minimaal 2 spelers nodig voordat een spel gestart kan worden. Maak eerst spelers aan.");
                return false;
            }

            return true;
        }

        private void BtnNewMatch_Click(object sender, EventArgs e)
        {
            if (!CheckGameCanStart())
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
                MessageBox.Show("Exporteren van data alleen voor local storage mogelijk.");
                return;
            }

            if (Directory.GetFiles(localStoragePath).Length ==0)
            {
                MessageBox.Show("Geen data gevonden");
                return;
            }

            sfdZipfile.Filter = "Zip|*.zip";
            sfdZipfile.Title = "Save backup zip file";

            var targetLocation = sfdZipfile.ShowDialog();
            if (DialogResult.OK != targetLocation)
            {
                MessageBox.Show("Opslaan geannuleerd");
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
    }
}
