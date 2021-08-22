using System;
using System.Windows.Forms;
using ttManager.Data.data;
using ttManager.Data.data.requests;
using ttManager.Data.Helpers;
using ttManager.Data.models;

namespace ttManager.forms
{
    public partial class ContinueMatchSelection : Form
    {
        public ContinueMatchSelection()
        {
            InitializeComponent();

            LoadUnfinishedMatches();
        }

        private void LbUnfinishedMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Match)lbUnfinishedMatches.SelectedItem != null)
            {
                LoadMatch(((Match)lbUnfinishedMatches.SelectedItem));
            }
        }

        private void LoadUnfinishedMatches()
        {
            var filter = new FilterObject
            {
                Column = "WinnerId",
                Value = "ISNULL"
            };
            var matchesWithoutWinner = MatchData.Get(filter);

            lbUnfinishedMatches.DataSource = matchesWithoutWinner;
            lbUnfinishedMatches.DisplayMember = "MatchDescription";

            if (matchesWithoutWinner.Count == 0)
            {
                Close();
            }
        }

        private void BtnContinueMatch_Click(object sender, EventArgs e)
        {
            Hide();
            PlayMatch playMatch = new PlayMatch(((Match)lbUnfinishedMatches.SelectedItem));
            playMatch.ShowDialog();
            Close();
        }

        private void LoadMatch(Match match)
        {
            var matchSummary = MatchHelper.GetMatchSummary(match);

            txtTeamLeft.Text = matchSummary.TeamLeft;
            txtTeamRight.Text = matchSummary.TeamRight;
            txtMatchDate.Text = matchSummary.MatchDate;
            txtGames.Text = matchSummary.GamesSummary;
            txtStandings.Text = matchSummary.Standings;
        }

        private void LbUnfinishedMatches_DoubleClick(object sender, EventArgs e)
        {
            BtnContinueMatch_Click(sender, e);
        }
    }
}
