using Scoreboard.DataCore.Data;
using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System;
using System.Windows.Forms;

namespace Scoreboard.forms
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
                LoadMatch((Match)lbUnfinishedMatches.SelectedItem);
            }
        }

        private void LoadUnfinishedMatches()
        {
            FilterObject filter = new FilterObject
            {
                Column = "WinnerId",
                Value = "ISNULL"
            };
            System.Collections.Generic.List<Match> matchesWithoutWinner = MatchData.Get(filter);

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
            PlayMatch playMatch = new PlayMatch((Match)lbUnfinishedMatches.SelectedItem);
            _ = playMatch.ShowDialog();
            Close();
        }

        private void LoadMatch(Match match)
        {
            MatchSummary matchSummary = MatchHelper.GetMatchSummary(match);

            txtTeamLeft.Text = matchSummary.TeamLeft;
            txtTeamRight.Text = matchSummary.TeamRight;
            txtMatchDate.Text = matchSummary.MatchDate;
            txtSets.Text = matchSummary.SetsSummary;
            txtStandings.Text = matchSummary.Standings;
        }

        private void LbUnfinishedMatches_DoubleClick(object sender, EventArgs e)
        {
            BtnContinueMatch_Click(sender, e);
        }
    }
}
