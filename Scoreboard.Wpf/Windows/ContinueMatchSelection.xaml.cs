using Scoreboard.DataCore.Data;
using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for ContinueMatchSelection.xaml
    /// </summary>
    public partial class ContinueMatchSelection : Window
    {
        public ContinueMatchSelection()
        {
            InitializeComponent(); 
            WpfHelper.SetLanguageResourceDictionary(this, MethodBase.GetCurrentMethod().DeclaringType.Name);

            LoadUnfinishedMatches();
        }

        private void LbMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Match)lbUnfinishedMatches.SelectedItem != null)
            {
                LoadMatch((Match)lbUnfinishedMatches.SelectedItem);
            }
        }

        private void LoadUnfinishedMatches()
        {
            FilterObject filter = new()
            {
                Column = "WinnerId",
                Value = "ISNULL"
            };
            List<Match> matchesWithoutWinner = MatchData.Get(filter);

            lbUnfinishedMatches.ItemsSource = matchesWithoutWinner;
            lbUnfinishedMatches.DisplayMemberPath = "MatchDescription";

            if (matchesWithoutWinner.Count == 0)
            {
                Close();
            }
            else
            {
                lbUnfinishedMatches.SelectedIndex = 0;
            }
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PlayMatch playMatch = new((Match)lbUnfinishedMatches.SelectedItem, false);
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

        private void LbUnfinishedMatches_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BtnContinue_Click(sender, e);
        }
    }
}
