using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournament : Window
    {
        private readonly Boolean isInitialized = false;
        private List<Player> playerList = new();
        public CreateTournament()
        {
            InitializeComponent();
            WpfHelper.SetLanguageResourceDictionary(this, MethodBase.GetCurrentMethod().DeclaringType.Name);

            LoadData();

            isInitialized = true;
        }

        private void LoadData()
        {
            playerList = PlayerData.Get().OrderByDescending(p => p.PlayedGames).ThenBy(p => p.Name).ToList();
            foreach(var player in playerList)
            {
                lbAvailablePlayers.Items.Add(player);
            }
            lbAvailablePlayers.DisplayMemberPath = "Name";
            lbSelectedPlayers.DisplayMemberPath = "Name";
            lbAvailablePlayers.SelectedValuePath = "Id";
            lbSelectedPlayers.SelectedValuePath = "Id";
            cboMatchType.ItemsSource = MatchTypeData.Get().OrderByDescending(m => m.PlayedMatches).ThenBy(m => m.Type).ToList();
            cboMatchType.DisplayMemberPath = "Type";
            lbSelectedPlayers.SelectedIndex = 0;
            lbAvailablePlayers.SelectedIndex = 0;
            cboMatchType.SelectedIndex = 0;
        }

        private void CboMatchType_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MatchType matchType = (MatchType)cboMatchType.SelectedItem;
            txtMatchTypeDescription.Text = matchType.Description;
        }

        private void BtnStartNewTournament_Click(object sender, RoutedEventArgs e)
        {
            if (lbSelectedPlayers.Items.Count < 3)
            {
                return;
            }

            var tournament = new Tournament()
            {
                MatchTypeId = ((MatchType)(cboMatchType.SelectedItem)).Id,
                TournamentDateParsed = DateTime.Now
            };

            var playersInTournament = new List<Player>();
            foreach(var p in lbSelectedPlayers.Items)
            {
                playersInTournament.Add((Player)p);
            }
            tournament.MatchSchema = TournamentHelper.GetTournamentSchema(playersInTournament);
            tournament = TournamentData.Create(tournament);

            // Play the whole schema
            foreach(var tm in tournament.MatchSchema)
            {
                PlayMatch(tournament, tm);
            }

            var finaleTournamentMatch = TournamentHelper.GetFinaleForTournament(tournament, playersInTournament);
            var playerLeft = playersInTournament.Find(p => p.Id == finaleTournamentMatch.PlayerLeftId);
            var playerRight = playersInTournament.Find(p=> p.Id == finaleTournamentMatch.PlayerRightId);
            var finaleMatchText = playerLeft.Name + " - " + playerRight.Name;

            MessageBox.Show(WpfHelper.GetResourceText("finale") + finaleMatchText, WpfHelper.GetResourceText("finaleTitle") , MessageBoxButton.OK);

            PlayMatch(tournament, finaleTournamentMatch);
        }

        private void PlayMatch(Tournament tournament, TournamentMatch tournamentMatch)
        {
            Match newMatch = new()
            {
                MatchTypeId = tournament.MatchTypeId,
                PlayerLeftId = tournamentMatch.PlayerLeftId,
                PlayerRightId = tournamentMatch.PlayerRightId,
                TournamentId = tournament.Id
            };

            var selectedPlayersForMatch = new List<int>
                {
                    newMatch.PlayerLeftId,
                    newMatch.PlayerRightId
                };

            // Randomize player first serve
            Random random = new();
            int index = random.Next(selectedPlayersForMatch.Count);
            newMatch.PlayerFirstServiceId = selectedPlayersForMatch[index];

            newMatch.MatchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Match m = MatchData.Create(newMatch);

            tournamentMatch.MatchId = m.Id;
            tournamentMatch.PlayerRightId = m.PlayerRightId;
            tournamentMatch.PlayerLeftId = m.PlayerLeftId;
            TournamentData.Update(tournament);

            Hide();
            PlayMatch frmPlayMatch = new(m, true);
            _ = frmPlayMatch.ShowDialog();
            Close();
        }

        private void LbSelectedPlayers_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((Player)lbSelectedPlayers.SelectedItem != null && isInitialized)
            {
                lbAvailablePlayers.Items.Add(lbSelectedPlayers.SelectedItem);
                lbSelectedPlayers.Items.Remove(lbSelectedPlayers.SelectedItem);
            }
        }

        private void LbAvailablePlayers_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((Player)lbAvailablePlayers.SelectedItem != null && isInitialized)
            {
                lbSelectedPlayers.Items.Add(lbAvailablePlayers.SelectedItem);
                lbAvailablePlayers.Items.Remove(lbAvailablePlayers.SelectedItem);
            }
        }
    }
}