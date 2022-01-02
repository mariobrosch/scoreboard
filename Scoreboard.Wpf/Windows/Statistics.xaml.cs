using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        readonly List<Player> Players = new();
        readonly List<Match> Matches = new();
        readonly List<SinglePlayerMatch> SinglePlayerMatches = new();
        List<StatsModel> StatsModels = new();

        public Statistics()
        {
            InitializeComponent();
            WpfHelper.SetLanguageResourceDictionary(this, MethodBase.GetCurrentMethod().DeclaringType.Name);

            // Get all data, fine to have them all at once
            Players = PlayerData.Get();
            Matches = MatchData.Get();
            SinglePlayerMatches = SinglePlayerMatchData.Get();
        }

        private void SetStatisticsInWindow(string title, SelectedValueType type, bool descending = true)
        {
            var data = "";
            var counter = 1;
            switch (type)
            {
                case SelectedValueType.DECIMAL:
                    var orderedStatsDecimal = (descending ? StatsModels.OrderByDescending(x => x.ValueAsDecimal) : StatsModels.OrderBy(x => x.ValueAsDecimal));
                    foreach (var player in orderedStatsDecimal)
                    {
                        data += counter.ToString() + ": " + player.KeyValue + " - " + player.ValueAsDecimal.ToString() + "\n";
                        counter++;
                        if (counter > 10)
                        {
                            break;
                        }
                    }
                    break;
                case SelectedValueType.STRING:
                    var orderedStatsString = (descending ? StatsModels.OrderByDescending(x => x.ValueAsString) : StatsModels.OrderBy(x => x.ValueAsString));
                    foreach (var player in orderedStatsString)
                    {
                        data += counter.ToString() + ": " + player.KeyValue + " - " + player.ValueAsString + "\n";
                        counter++;
                        if (counter > 10)
                        {
                            break;
                        }
                    }
                    break;
                case SelectedValueType.INT:
                    var orderedStatsInt = (descending ? StatsModels.OrderByDescending(x => x.ValueAsInt) : StatsModels.OrderBy(x => x.ValueAsInt));
                    foreach (var player in orderedStatsInt)
                    {
                        data += counter.ToString() + ": " + player.KeyValue + " - " + player.ValueAsInt.ToString() + "\n";
                        counter++;
                        if (counter > 10)
                        {
                            break;
                        }
                    }
                    break;
            }
            TxtSelectedStats.Text = title;
            TxtStatistics.Text = data;
        }

        private static TextBlock GetChildTextblock(object sender)
        {
            var thisElement = ((ListBoxItem)sender);
            TextBlock foundTextBox = WpfHelper.FindChild<TextBlock>(thisElement, "Txt" + thisElement.Name);
            return foundTextBox;
        }

        private void ClearPreviousStats()
        {
            StatsModels = new();
        }

        private void MostMatchesWon_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var foundTextBox = GetChildTextblock(sender);
            ClearPreviousStats();

            foreach (var player in Players)
            {
                var statsModel = new StatsModel
                {
                    KeyId = player.Id,
                    KeyValue = player.Name,
                    ValueAsInt = GetNumberOfMatchesWonByPlayer(player.Id)
                };

                StatsModels.Add(statsModel);
            }

            SetStatisticsInWindow(foundTextBox.Text, SelectedValueType.INT);
        }

        private void BestSinglePlayer_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var foundTextBox = GetChildTextblock(sender);
            ClearPreviousStats();

            foreach (var player in Players)
            {
                var statsModel = new StatsModel
                {
                    KeyId = player.Id,
                    KeyValue = player.Name,
                    ValueAsInt = GetBestSinglePlayerScoreForPlayer(player.Id)
                };

                StatsModels.Add(statsModel);
            }

            SetStatisticsInWindow(foundTextBox.Text, SelectedValueType.INT);
        }

        private void MostPlayed_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var foundTextBox = GetChildTextblock(sender);
            ClearPreviousStats();

            foreach (var player in Players)
            {
                var statsModel = new StatsModel
                {
                    KeyId = player.Id,
                    KeyValue = player.Name,
                    ValueAsInt = GetNumberOfMatchesPlayedByPlayer(player.Id)
                };
                StatsModels.Add(statsModel);
            }

            SetStatisticsInWindow(foundTextBox.Text, SelectedValueType.INT);
        }

        private void BestWinRatio_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var foundTextBox = GetChildTextblock(sender);
            ClearPreviousStats();

            foreach (var player in Players)
            {
                var statsModel = new StatsModel
                {
                    KeyId = player.Id,
                    KeyValue = player.Name
                };

                var wonMatches = GetNumberOfMatchesWonByPlayer(player.Id);
                var totalPlayed = GetNumberOfMatchesPlayedByPlayer(player.Id);
                statsModel.ValueAsDecimal = Math.Round( (decimal)wonMatches / (decimal)totalPlayed * (decimal)100, 2);

                StatsModels.Add(statsModel);
            }

            SetStatisticsInWindow(foundTextBox.Text, SelectedValueType.DECIMAL);
        }

        private void MostMatchesLost_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var foundTextBox = GetChildTextblock(sender);
            ClearPreviousStats();

            foreach (var player in Players)
            {
                var statsModel = new StatsModel
                {
                    KeyId = player.Id,
                    KeyValue = player.Name,
                    ValueAsInt = GetNumberOfMatchesLostByPlayer(player.Id)
                };
                StatsModels.Add(statsModel);
            }

            SetStatisticsInWindow(foundTextBox.Text, SelectedValueType.INT);
        }

        private int GetNumberOfMatchesPlayedByPlayer(int playerId)
        {
            return Matches.FindAll(match => match.PlayerLeftId == playerId || match.PlayerLeftId2 == playerId || match.PlayerRightId == playerId || match.PlayerRightId2 == playerId).Count;
        }

        private int GetNumberOfMatchesWonByPlayer(int playerId)
        {
            return Matches.FindAll(m => m.WinnerId == playerId || m.WinnerId2.GetValueOrDefault() == playerId).Count;
        }

        private int GetNumberOfMatchesLostByPlayer(int playerId)
        {
            var count = 0;
            foreach (var match in Matches)
            {
                if (!match.WinnerId.HasValue)
                {
                    continue;
                }
                if (match.WinnerId.Value != playerId && ((match.WinnerId2.HasValue && match.WinnerId2 != playerId) || match.WinnerId2.HasValue == false))
                {
                    if (match.PlayerLeftId == playerId || match.PlayerLeftId2 == playerId || match.PlayerRightId == playerId || match.PlayerRightId2 == playerId)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int GetBestSinglePlayerScoreForPlayer(int playerId)
        {
            var singlePlayerMatches = SinglePlayerMatches.FindAll(s => s.PlayerId == playerId);
            var highestScore = 0;
            foreach(var singleMatch in singlePlayerMatches)
            {
                if (singleMatch.HighScore > highestScore)
                {
                    highestScore = singleMatch.HighScore;
                }
            }

            return highestScore;
        }
    }

    public enum SelectedValueType
    {
        STRING,
        INT,
        DECIMAL
    }
}
