using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Enums;
using Scoreboard.DataCore.Helpers;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for PlayMatch.xaml
    /// </summary>
    public partial class PlayMatch : Window
    {
        private readonly Match match;
        private MatchSummary matchSummary;
        private Set currentSet;
        private bool setFinished;
        private readonly Timer matchTimer = new(1000);
        private readonly DateTime sessionStart;
        private int secondsPlayedThisSession;
        public PlayMatch(Match m)
        {
            InitializeComponent();
            sessionStart = DateTime.Now;
            matchTimer.Elapsed += UpdateMatchTime;
            matchTimer.Start();

            match = m;
            if (match.Id == 0)
            {
                Close();
            }
            matchSummary = MatchHelper.GetMatchSummary(match);
            UpdateMatchTime(null, null);
            if (matchSummary.Sets.Count == 0)
            {
                currentSet = new Set
                {
                    SetNumber = 1,
                    MatchId = match.Id
                };
                currentSet = SetData.Create(currentSet);
            }
            else
            {
                currentSet = matchSummary.Sets[matchSummary.Sets.Count - 1];
            }
            txtScoreLeft.Text = currentSet.TeamLeftScore.ToString();
            txtScoreRight.Text = currentSet.TeamRightScore.ToString();
            FillTopInfo();
            IsSetWinner();
            UpdateMatch();
        }

        private void UpdateMatchTime(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (matchSummary != null)
                {
                    int interval = Convert.ToInt32((DateTime.Now - sessionStart).TotalSeconds);
                    string maxMatchTime = "";
                    if (!match.WinnerId.HasValue)
                    {
                        secondsPlayedThisSession = interval;
                    }

                    if (matchSummary.SecondsPlayed > 0)
                    {
                        interval += matchSummary.SecondsPlayed;
                    }

                    if (matchSummary.MatchType.MatchTime.HasValue
                        && matchSummary.MatchType.MatchTime.Value > 0
                        && matchSummary.MatchType.IsTimedMatch)
                    {
                        maxMatchTime = " / ";
                        int maxMatchTimeInSeconds = matchSummary.MatchType.MatchTime.Value * 60;
                        TimeSpan timeMax = TimeSpan.FromSeconds(maxMatchTimeInSeconds);
                        if (maxMatchTimeInSeconds > 3599)
                        {
                            maxMatchTime += timeMax.ToString(@"hh\:mm\:ss");
                        }
                        else
                        {
                            maxMatchTime += timeMax.ToString(@"mm\:ss");
                        }
                    }

                    TimeSpan time = TimeSpan.FromSeconds(interval);
                    string str = interval > 3599 ? time.ToString(@"hh\:mm\:ss") : time.ToString(@"mm\:ss");
                    txtTimePlayed.Text = str + maxMatchTime;
                }
            });
        }

        private void FillTopInfo()
        {
            txtLeftTeam.Text = matchSummary.TeamLeft + " (" + matchSummary.Standings.Split('-')[0] + ")";
            txtRightTime.Text = matchSummary.TeamRight + " (" + matchSummary.Standings.Split('-')[1] + ")";
        }

        private void TxtScoreRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UpdateScore(false);

        }

        private void TxtScoreLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UpdateScore(true);

        }

        private void UpdateScore(bool isForLeft, bool negativeScore = false)
        {
            if (currentSet.SetWinnerId.HasValue)
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("setPlayedErrorDesc"));
            }
            else if (matchSummary.Winner.HasValue)
            {
                _ = MessageBox.Show(WpfHelper.GetResourceText("matchPlayedErrorDesc"));
            }
            else if (isForLeft)
            {
                if (negativeScore)
                {
                    if (currentSet.TeamLeftScore > 0)
                    {
                        currentSet.TeamLeftScore--;
                    }
                }
                else
                {
                    currentSet.TeamLeftScore++;
                }
                txtScoreLeft.Text = currentSet.TeamLeftScore.ToString();
            }
            else
            {
                if (negativeScore)
                {
                    if (currentSet.TeamRightScore > 0)
                    {
                        currentSet.TeamRightScore--;
                    }
                }
                else
                {
                    currentSet.TeamRightScore++;
                }
                txtScoreRight.Text = currentSet.TeamRightScore.ToString();
            }
            IsSetWinner();
            _ = SetData.Update(currentSet);
            UpdateMatch();
            FillTopInfo();
        }

        private void UpdateMatch()
        {
            matchSummary = MatchHelper.GetMatchSummary(match);

            if (setFinished)
            {
                PlayerSide matchWinner = MatchHelper.HasMatchWinner(matchSummary, secondsPlayedThisSession);

                if (matchWinner == PlayerSide.None)
                {
                    // No update needed, all data is in the sets, just refetch the summary
                    matchSummary = MatchHelper.GetMatchSummary(match);
                    StartNewSet();
                    return;
                }

                if (matchWinner == PlayerSide.Left)
                {
                    WpfHelper.PlaySound(SoundTypes.Applause);
                    match.WinnerId = match.PlayerLeftId;
                    match.WinnerId2 = match.PlayerLeftId2;
                    txtLeftTeam.Background = new SolidColorBrush(Colors.Green);
                    txtWinner.Text = WpfHelper.GetResourceText("team") + " '" + matchSummary.TeamLeft + "' " + WpfHelper.GetResourceText("hasWon");
                    txtWinner.Visibility = Visibility.Visible;
                }

                if (matchWinner == PlayerSide.Right)
                {
                    WpfHelper.PlaySound(SoundTypes.Applause);
                    match.WinnerId = match.PlayerRightId;
                    match.WinnerId2 = match.PlayerRightId2;
                    txtRightTime.Background = new SolidColorBrush(Colors.Green);
                    txtWinner.Text = WpfHelper.GetResourceText("team") + " '" + matchSummary.TeamRight + "' " + WpfHelper.GetResourceText("hasWon");
                    txtWinner.Visibility = Visibility.Visible;
                }

                _ = MatchData.Update(match);
                matchSummary = MatchHelper.GetMatchSummary(match);

                return;
            }

            PlayerSide teamToServe = SetHelper.GetPlayerToServe(matchSummary);
            if (teamToServe == PlayerSide.Left)
            {
                txtScoreLeft.Background = new SolidColorBrush(Colors.Yellow);
                txtScoreRight.Background = new SolidColorBrush(Colors.White);
            }
            else if (teamToServe == PlayerSide.Right)
            {
                txtScoreLeft.Background = new SolidColorBrush(Colors.White);
                txtScoreRight.Background = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                txtScoreLeft.Background = new SolidColorBrush(Colors.White);
                txtScoreRight.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void IsSetWinner()
        {
            PlayerSide setWinner = SetHelper.HasWinner(currentSet, matchSummary.MatchType, secondsPlayedThisSession + matchSummary.SecondsPlayed);

            if (setWinner == PlayerSide.None)
            {
                return;
            }

            txtScoreLeft.IsEnabled = false;
            txtScoreRight.IsEnabled = false;
            setFinished = true;

            if (setWinner == PlayerSide.Left)
            {
                currentSet.SetWinnerId = match.PlayerLeftId;
                if (match.PlayerLeftId2.HasValue)
                {
                    currentSet.SetWinnerId2 = match.PlayerLeftId2;
                }
                txtScoreLeft.Background = new SolidColorBrush(Colors.Green);
                return;
            }

            if (setWinner == PlayerSide.Right)
            {
                currentSet.SetWinnerId = match.PlayerRightId;
                if (match.PlayerRightId2.HasValue)
                {
                    currentSet.SetWinnerId2 = match.PlayerRightId2;
                }
                txtScoreRight.Background = new SolidColorBrush(Colors.Green);
                return;
            }
        }


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            List<Key> helpKeys = new()
            {
                Key.H,
                Key.F1
            };

            List<Key> playerLeftKeys = new()
            {
                Key.L,
                Key.Left,
                Key.LeftShift,
                Key.NumPad7
            };

            List<Key> playerRightKeys = new()
            {
                Key.R,
                Key.RightShift,
                Key.Right,
                Key.NumPad9
            };

            if (helpKeys.Contains(e.Key))
            {
                string helpText = WpfHelper.GetResourceText("help1") + "\r\n";
                helpText += WpfHelper.GetResourceText("help2") + "\r\n\r\n";
                helpText += WpfHelper.GetResourceText("help3") + "\r\n";
                helpText += WpfHelper.GetResourceText("help4") + "\r\n";
                helpText += WpfHelper.GetResourceText("help5") + "\r\n\r\n";
                helpText += WpfHelper.GetResourceText("help6") + "\r\n\r\n";

                _ = MessageBox.Show(helpText, WpfHelper.GetResourceText("help"));
            }

            if (playerLeftKeys.Contains(e.Key))
            {
                UpdateScore(true);
            }

            if (playerRightKeys.Contains(e.Key))
            {
                UpdateScore(false);
            }

            if (e.Key is Key.Z or Key.NumPad1)
            {
                UpdateScore(true, true);
            }

            if (e.Key is Key.X or Key.NumPad3)
            {
                UpdateScore(false, true);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            match.PlayTimeSeconds = secondsPlayedThisSession + matchSummary.SecondsPlayed;
            _ = MatchData.Update(match);

            WpfHelper.WriteToBackupLocation();
        }

        private void StartNewSet()
        {
            if (MessageBox.Show(WpfHelper.GetResourceText("startNextSet"), WpfHelper.GetResourceText("startNextSet"), MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                txtScoreLeft.Text = "0";
                txtScoreLeft.IsEnabled = true;
                txtScoreRight.Text = "0";
                txtScoreRight.IsEnabled = true;
                Set set = new()
                {
                    SetNumber = matchSummary.Sets.Count + 1,
                    MatchId = match.Id,
                    TeamLeftScore = 0,
                    TeamRightScore = 0
                };
                currentSet = SetData.Create(set);
                setFinished = false;
                UpdateMatch();
                txtScoreRight.Background = new SolidColorBrush(Colors.White);
                txtScoreLeft.Background = new SolidColorBrush(Colors.White);
            }
        }
    }
}
