using Microsoft.Win32;
using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for Players.xaml
    /// </summary>
    public partial class Players : Window
    {
        private List<Player> players;
        private Player currentPlayer;
        public Players()
        {
            InitializeComponent();

            LoadPlayers();
        }

        private void LoadPlayers()
        {
            players = PlayerData.Get(ChkShowRemoved.IsChecked.GetValueOrDefault())?.OrderBy(p => p.Name).ToList();

            lbPlayers.ItemsSource = players;
            lbPlayers.DisplayMemberPath = "Name";

            if (players.Count == 0)
            {
                txtId.Text = WpfHelper.GetResourceText("new");
            }
            else
            {
                lbPlayers.SelectedIndex = 0;
            }
        }

        private void ChkShowRemoved_Click(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            lbPlayers.UnselectAll();
            txtName.Text = "";
            txtId.Text = WpfHelper.GetResourceText("new");
            txtPhotoUrl.Text = "";
            pbPhoto.Source = null;
            chkActivePlayer.IsChecked = true;
            BtnRemove.Visibility = Visibility.Hidden;
            btnRemovePhoto.Visibility = Visibility.Hidden;
            lblSinglePlayerStats.Text = "";
            lblPlayerStats.Text = "";
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            List<Match> matchesForPlayer = MatchData.GetForPlayer(int.Parse(txtId.Text));

            if (matchesForPlayer.Count == 0)
            {
                if (MessageBox.Show(WpfHelper.GetResourceText("RemovePlayerCompletely"), WpfHelper.GetResourceText("RemovePlayerCompletelyTitle"), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _ = PlayerData.Delete(txtId.Text);
                    LoadPlayers();
                }
            }
            else if (MessageBox.Show(WpfHelper.GetResourceText("removePlayer"), WpfHelper.GetResourceText("remove"), MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Player player = (Player)lbPlayers.SelectedItem;
                player.IsRemoved = true;
                _ = PlayerData.Update(player);
                LoadPlayers();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != WpfHelper.GetResourceText("new"))
            {
                Player player = (Player)lbPlayers.SelectedItem;
                if (player == null)
                {
                    return;
                }
                player.IsEnabled = chkActivePlayer.IsChecked.GetValueOrDefault();
                player.Name = txtName.Text;
                player.PhotoUrl = txtPhotoUrl.Text;

                _ = PlayerData.Update(player);
            }
            else
            {
                Player newPlayer = new()
                {
                    IsEnabled = chkActivePlayer.IsChecked.GetValueOrDefault(),
                    Name = txtName.Text,
                    PhotoUrl = txtPhotoUrl.Text,
                    IsRemoved = chkRemovedPlayer.IsChecked.GetValueOrDefault()
                };

                _ = PlayerData.Create(newPlayer);
            }
            LoadPlayers();
        }

        private void BtnUploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPhoto = new()
            {
                Filter = "Jpg|*.jpg",
                Title = WpfHelper.GetResourceText("OpenPhoto")
            };

            if (ofdPhoto.ShowDialog() ==true)
            {
                byte[] imageArray = File.ReadAllBytes(ofdPhoto.FileName);
                currentPlayer.Photo = Convert.ToBase64String(imageArray);
                _ = PlayerData.Update(currentPlayer);
                LoadPhoto();
            }
        }

        private void BtnRemovePhoto_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer.Photo = "";
            _ = PlayerData.Update(currentPlayer);
            LoadPhoto();
        }

        private void LbPlayers_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((Player)lbPlayers.SelectedItem != null)
            {
                LoadPlayer((Player)lbPlayers.SelectedItem);
            }
        }

        private void LoadPlayer(Player player)
        {
            txtId.Text = player.Id.ToString();
            txtName.Text = player.Name;
            txtPhotoUrl.Text = player.PhotoUrl;
            chkActivePlayer.IsChecked = player.IsEnabled;
            chkRemovedPlayer.IsChecked = player.IsRemoved;

            BtnRemove.Visibility = Visibility.Visible;

            List<SinglePlayerMatch> singlePlayerMatches = SinglePlayerMatchData.GetForPlayer(player.Id);
            if (singlePlayerMatches.Count > 0)
            {
                SinglePlayerMatch bestMatch = singlePlayerMatches.OrderBy(x => x.HighScore).Last();
                lblSinglePlayerStats.Text = singlePlayerMatches.Count + " " + WpfHelper.GetResourceText("singlePlayerStat") + " " + bestMatch.MatchDateParsed.ToString("yyyy-MM-dd") + " met als score " + bestMatch.HighScore.ToString();
            }
            else
            {
                lblSinglePlayerStats.Text = "-";
            }

            List<Match> matchesForPlayer = MatchData.GetForPlayer(player.Id);
            int matchesWon = matchesForPlayer.Where(m => m.WinnerId == player.Id).ToList().Count;
            lblPlayerStats.Text = matchesForPlayer.Count > 0 ? matchesForPlayer.Count.ToString() + " " + WpfHelper.GetResourceText("played") + " " + WpfHelper.GetResourceText("and") + matchesWon.ToString() + " " + WpfHelper.GetResourceText("won") : "0";
            currentPlayer = player;

            LoadPhoto();
        }

        private void TxtPhotoUrl_LostFocus(object sender, RoutedEventArgs e)
        {
            currentPlayer.PhotoUrl = txtPhotoUrl.Text;
            LoadPhoto();
        }

        private void LoadPhoto()
        {
            btnRemovePhoto.Visibility = Visibility.Hidden;
            if (!string.IsNullOrEmpty(currentPlayer.Photo))
            {
                byte[] binaryData = Convert.FromBase64String(currentPlayer.Photo);

                BitmapImage bi = new();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                Image img = new();
                img.Source = bi;
                
                btnRemovePhoto.Visibility = Visibility.Visible;
            }
            else if (!string.IsNullOrEmpty(currentPlayer.PhotoUrl))
            {
                Image image = new();
                string fullFilePath = currentPlayer.PhotoUrl;

                BitmapImage bitmap = new();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;
            }
            else
            {
                pbPhoto.Source = null;
            }
        }

        private void LbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Player)lbPlayers.SelectedItem != null)
            {
                LoadPlayer((Player)lbPlayers.SelectedItem);
            }
        }
    }
}
