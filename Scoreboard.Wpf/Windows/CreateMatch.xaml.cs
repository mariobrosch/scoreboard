using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for CreateMatch.xaml
    /// </summary>
    public partial class CreateMatch : Window
    {

        public CreateMatch()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            cboPlayerLeft.ItemsSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerLeft2.ItemsSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerRight.ItemsSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerRight2.ItemsSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerLeft.DisplayMemberPath = "Name";
            cboPlayerLeft2.DisplayMemberPath = "Name";
            cboPlayerRight.DisplayMemberPath = "Name";
            cboPlayerRight2.DisplayMemberPath = "Name";
            cboMatchType.ItemsSource = MatchTypeData.Get().OrderBy(m => m.Type).ToList();
            cboMatchType.DisplayMemberPath = "Type";
        }

        private bool IsPlayerDouble()
        {
            Player playerLeft = (Player)cboPlayerLeft.SelectedItem;
            Player playerRight = (Player)cboPlayerRight.SelectedItem;

            if (playerLeft.Id == playerRight.Id)
            {
                return true;
            }

            if (chkTwoVsTwoMatch.IsChecked == false)
            {
                return false;
            }

            Player playerLeft2 = (Player)cboPlayerLeft2.SelectedItem;
            Player playerRight2 = (Player)cboPlayerRight2.SelectedItem;

            List<int> playerList = new()
            {
                playerLeft.Id,
                playerRight.Id,
                playerLeft2.Id,
                playerRight2.Id
            };

            IOrderedEnumerable<(int Value, int Count)> result = playerList.GroupBy(id => id)
                        .Select(g => (Value: g.Key, Count: g.Count()))
                        .OrderByDescending(x => x.Count);

            foreach ((int Value, int Count) in result)
            {
                if (Count > 1)
                {
                    return true;
                }
            }
            return false;
        }
        private void ChkTwoVsTwoMatch_CheckedChanged(object sender, RoutedEventArgs e)
        {
            lblPlayerLeft2.Visibility = chkTwoVsTwoMatch.IsChecked.GetValueOrDefault() ? Visibility.Visible : Visibility.Hidden;
            cboPlayerLeft2.Visibility = chkTwoVsTwoMatch.IsChecked.GetValueOrDefault() ? Visibility.Visible : Visibility.Hidden;
            lblPlayerRight2.Visibility = chkTwoVsTwoMatch.IsChecked.GetValueOrDefault() ? Visibility.Visible : Visibility.Hidden;
            cboPlayerRight2.Visibility = chkTwoVsTwoMatch.IsChecked.GetValueOrDefault() ? Visibility.Visible : Visibility.Hidden;
        }

        private void CboMatchType_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MatchType matchType = (MatchType)cboMatchType.SelectedItem;
            txtMatchTypeDescription.Text = matchType.Description;
        }

        private void BtnStartNewSet_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlayerDouble())
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("setupErrorDescription"), WpfHelper.GetResourceText("setupErrorTitle"));
                return;
            }
            List<int> selectedPlayersForMatch = new();
            Player playerLeft = (Player)cboPlayerLeft.SelectedItem;
            Player playerRight = (Player)cboPlayerRight.SelectedItem;
            MatchType matchType = (MatchType)cboMatchType.SelectedItem;

            Match newMatch = new()
            {
                MatchTypeId = matchType.Id,
                PlayerLeftId = playerLeft.Id,
                PlayerRightId = playerRight.Id
            };

            selectedPlayersForMatch.Add(playerLeft.Id);
            selectedPlayersForMatch.Add(playerRight.Id);

            if (chkTwoVsTwoMatch.IsChecked == true)
            {
                Player playerLeft2 = (Player)cboPlayerLeft2.SelectedItem;
                Player playerRight2 = (Player)cboPlayerRight2.SelectedItem;
                newMatch.PlayerLeftId2 = playerLeft2.Id;
                newMatch.PlayerRightId2 = playerRight2.Id;
                selectedPlayersForMatch.Add(playerLeft2.Id);
                selectedPlayersForMatch.Add(playerRight2.Id);
            }

            // Randomize player first serve
            Random random = new();
            int index = random.Next(selectedPlayersForMatch.Count);
            newMatch.PlayerFirstServiceId = selectedPlayersForMatch[index];

            newMatch.MatchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Match m = MatchData.Create(newMatch);

            Hide();
            PlayMatch frmPlayMatch = new(m);
            frmPlayMatch.ShowDialog();
            Close();
        }
    }
}