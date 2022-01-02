using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for MatchTypes.xaml
    /// </summary>
    public partial class MatchTypes : Window
    {
        private List<MatchType> matchTypes;

        public MatchTypes()
        {
            InitializeComponent();
            WpfHelper.SetLanguageResourceDictionary(this, MethodBase.GetCurrentMethod().DeclaringType.Name);

            LoadMatchTypes();
        }
        private void LoadMatchTypes()
        {
            matchTypes = MatchTypeData.Get().OrderBy(mt => mt.Type).ToList();

            lbMatchTypes.ItemsSource = matchTypes;
            lbMatchTypes.DisplayMemberPath = "Type";

            if (matchTypes.Count == 0)
            {
                txtId.Text = WpfHelper.GetResourceText("new");
            } else
            {
                lbMatchTypes.SelectedIndex = 0;
            }
        }

        private void ChkShowRemoved_Click(object sender, RoutedEventArgs e)
        {
            LoadMatchTypes();
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            List<Match> matchesForMatchType = MatchData.GetForMatchType(int.Parse(txtId.Text));

            if (matchesForMatchType.Count == 0)
            {
                if (MessageBox.Show(WpfHelper.GetResourceText("matchTypeRemovedDescription"), WpfHelper.GetResourceText("completeRemove"), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _ = MatchTypeData.Delete(txtId.Text);
                    LoadMatchTypes();
                }
            }
            else if (MessageBox.Show(WpfHelper.GetResourceText("RemoveMatchType"), WpfHelper.GetResourceText("remove"), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MatchType matchType = (MatchType)lbMatchTypes.SelectedItem;
                matchType.IsRemoved = true;
                _ = MatchTypeData.Update(matchType);
                LoadMatchTypes();
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            lbMatchTypes.UnselectAll();
            txtTitle.Text = "";
            txtId.Text = WpfHelper.GetResourceText("new");
            txtDescription.Text = "";
            chkIsRemoved.IsChecked = false;
            numSetsToWin.Text = "1";
            numPointsPerSet.Text = "1";
            numServiceChangeAfter.Text = "1";
            chkTwoPointDifference.IsChecked = true;
            numServiceChangeShootOutAfter.Text = "1";
            chk2vs2.IsChecked = true;
            BtnRemove.Visibility = Visibility.Hidden;
            numMatchTime.Text = "1";
            lblPlayed.Text = "-";
            SetFieldsEnabled();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != WpfHelper.GetResourceText("new"))
            {
                MatchType matchType = (MatchType)lbMatchTypes.SelectedItem;
                matchType.Type = txtTitle.Text;
                matchType.Description = txtDescription.Text;
                matchType.NumberOfSetsToWin = Convert.ToInt32(numSetsToWin.Text);
                matchType.ScorePerSetToWin = Convert.ToInt32(numPointsPerSet.Text);
                matchType.ServiceChangeEveryNumberOfServices = Convert.ToInt32(numServiceChangeAfter.Text);
                matchType.NeedTwoPointsDifferenceToWin = chkTwoPointDifference.IsChecked.GetValueOrDefault();
                matchType.ServiceChangeOnShootOutPer = Convert.ToInt32(numServiceChangeShootOutAfter.Text);
                matchType.IsAvailableForTwoVsTwo = chk2vs2.IsChecked.GetValueOrDefault();
                matchType.IsTimedMatch = chkTimedMatch.IsChecked.GetValueOrDefault();
                matchType.MatchTime = Convert.ToInt32(numMatchTime.Text);

                _ = MatchTypeData.Update(matchType);
            }
            else
            {
                MatchType newMatchType = new()
                {
                    Type = txtTitle.Text,
                    Description = txtDescription.Text,
                    IsRemoved = chkIsRemoved.IsChecked.GetValueOrDefault(),
                    NumberOfSetsToWin = Convert.ToInt32(numSetsToWin.Text),
                    ScorePerSetToWin = Convert.ToInt32(numPointsPerSet.Text),
                    ServiceChangeEveryNumberOfServices = Convert.ToInt32(numServiceChangeAfter.Text),
                    NeedTwoPointsDifferenceToWin = chkTwoPointDifference.IsChecked.GetValueOrDefault(),
                    ServiceChangeOnShootOutPer = Convert.ToInt32(numServiceChangeShootOutAfter.Text),
                    IsAvailableForTwoVsTwo = chk2vs2.IsChecked.GetValueOrDefault(),
                    IsTimedMatch = chkTimedMatch.IsChecked.GetValueOrDefault(),
                    MatchTime = Convert.ToInt32(numMatchTime.Text)
                };

                _ = MatchTypeData.Create(newMatchType);
            }
            LoadMatchTypes();
        }

        private void LoadMatchType(MatchType matchType)
        {
            txtId.Text = matchType.Id.ToString();
            txtTitle.Text = matchType.Type;
            txtDescription.Text = matchType.Description;
            chkIsRemoved.IsChecked = matchType.IsRemoved;
            numSetsToWin.Text = matchType.NumberOfSetsToWin.ToString();
            numPointsPerSet.Text = matchType.ScorePerSetToWin.ToString();
            numServiceChangeAfter.Text = matchType.ServiceChangeEveryNumberOfServices.ToString();
            chkTwoPointDifference.IsChecked = matchType.NeedTwoPointsDifferenceToWin;
            numServiceChangeShootOutAfter.Text = matchType.ServiceChangeOnShootOutPer.ToString();
            chk2vs2.IsChecked = matchType.IsAvailableForTwoVsTwo;
            chkTimedMatch.IsChecked = matchType.IsTimedMatch;
            numMatchTime.Text = matchType.MatchTime.HasValue ? matchType.MatchTime.Value.ToString() : "0";
            BtnRemove.Visibility = Visibility.Visible;

            List<Match> matchesWithMatchType = MatchData.GetForMatchType(matchType.Id);
            lblPlayed.Text = matchesWithMatchType.Count > 0 ? matchesWithMatchType.Count.ToString() + " " + WpfHelper.GetResourceText("played") : "0";
        }

        private void ChkTimedMatch_Click(object sender, RoutedEventArgs e)
        {
            SetFieldsEnabled();
        }

        private void SetFieldsEnabled()
        {
            numSetsToWin.IsReadOnly = !chkTimedMatch.IsChecked.GetValueOrDefault();
            numPointsPerSet.IsReadOnly = chkTimedMatch.IsChecked.GetValueOrDefault();
            chkTwoPointDifference.IsEnabled = !chkTimedMatch.IsChecked.GetValueOrDefault();
            numServiceChangeShootOutAfter.IsReadOnly = !chkTimedMatch.IsChecked.GetValueOrDefault();
            numMatchTime.IsReadOnly = chkTimedMatch.IsChecked.GetValueOrDefault();
        }

        private void LbMatchTypes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((MatchType)lbMatchTypes.SelectedItem != null)
            {
                LoadMatchType((MatchType)lbMatchTypes.SelectedItem);
            }
            SetFieldsEnabled();
        }
    }
}
