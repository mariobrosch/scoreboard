using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Scoreboard.Data.data.requests;
using Scoreboard.Data.enums;
using Scoreboard.Data.Helpers;
using Scoreboard.Data.models;

namespace Scoreboard.forms
{
    public partial class PlayMatch : Form
    {
        private readonly Match match;
        private MatchSummary matchSummary;
        private Set currentSet;
        private bool setFinished = false;
        private readonly System.Timers.Timer matchTimer = new System.Timers.Timer(1000);
        private readonly DateTime sessionStart;
        private int secondsPlayedThisSession = 0;

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
            btnLeftScore.Text = currentSet.TeamLeftScore.ToString();
            btnRightScore.Text = currentSet.TeamRightScore.ToString();
            FillTopInfo();
            IsSetWinner();
            UpdateMatch();
        }

        private void UpdateMatchTime(object sender, ElapsedEventArgs e)
        {
            if (!InvokeRequired)
            {
                if (matchSummary == null )
                {
                    return;
                }

                var interval = Convert.ToInt32((DateTime.Now - sessionStart).TotalSeconds);
                var maxMatchTime = "";
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
                    var maxMatchTimeInSeconds = matchSummary.MatchType.MatchTime.Value * 60;
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
                string str;
                if (interval > 3599)
                {
                    str = time.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    str = time.ToString(@"mm\:ss");
                }

                lblTimePlayed.Text = str + maxMatchTime;
            }
            else
            {
                try
                {
                    Invoke(new Action<object, ElapsedEventArgs>(UpdateMatchTime), sender, e);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception) { }
#pragma warning restore CA1031 // Do not catch general exception types
            }
        }

        private void PlayMatch_Resize(object sender, EventArgs e)
        {
            try
            {
                splitContainer.SplitterDistance = Width / 2;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        private void FillTopInfo()
        {
            txtLeft.Text = matchSummary.TeamLeft + " (" + matchSummary.Standings.Split('-')[0] + ")";
            txtRight.Text = matchSummary.TeamRight + " (" + matchSummary.Standings.Split('-')[1] + ")";
            txtLeft.SelectionLength = 0;
            txtRight.SelectionLength = 0;
        }

        private void BtnLeftScore_Click(object sender, EventArgs e)
        {
            UpdateScore(true);
        }

        private void BtnRightScore_Click(object sender, EventArgs e)
        {
            UpdateScore(false);
        }

        private void UpdateScore(bool isForLeft, bool negativeScore = false)
        {
            if (currentSet.SetWinnerId.HasValue)
            {
                MessageBox.Show(FormsHelper.GetResourceText("setPlayedErrorDesc"));
            }
            else if (matchSummary.Winner.HasValue)
            {
                MessageBox.Show(FormsHelper.GetResourceText("matchPlayedErrorDesc"));
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
                btnLeftScore.Text = currentSet.TeamLeftScore.ToString();
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
                btnRightScore.Text = currentSet.TeamRightScore.ToString();
            }
            IsSetWinner();
            SetData.Update(currentSet);
            UpdateMatch();
            FillTopInfo();
        }

        private void UpdateMatch()
        {
            matchSummary = MatchHelper.GetMatchSummary(match);

            if (setFinished)
            {
                var matchWinner = MatchHelper.HasMatchWinner(matchSummary, secondsPlayedThisSession);

                if (matchWinner == PlayerSide.None)
                {
                    // No update needed, all data is in the sets, just refetch the summary
                    matchSummary = MatchHelper.GetMatchSummary(match);
                    btnStartNewSet.Visible = true;
                    return;
                }

                if (matchWinner == PlayerSide.Left)
                {
                    FormsHelper.PlaySound(SoundTypes.Applause);
                    match.WinnerId = match.PlayerLeftId;
                    match.WinnerId2 = match.PlayerLeftId2;
                    txtLeft.BackColor = Color.Green;
                    txtWinner.Text = FormsHelper.GetResourceText("team") + " '" + matchSummary.TeamLeft + "' " + FormsHelper.GetResourceText("hasWon");
                    txtWinner.Visible = true;
                    txtLeft.SelectionLength = 0;
                    txtWinner.SelectionLength = 0;
                }

                if (matchWinner == PlayerSide.Right)
                {
                    FormsHelper.PlaySound(SoundTypes.Applause);
                    match.WinnerId = match.PlayerRightId;
                    match.WinnerId2 = match.PlayerRightId2;
                    txtRight.BackColor = Color.Green;
                    txtRight.SelectionLength = 0;
                    txtWinner.Text = FormsHelper.GetResourceText("team") + " '" + matchSummary.TeamRight + "' " + FormsHelper.GetResourceText("hasWon");
                    txtWinner.Visible = true;
                    txtWinner.SelectionLength = 0;
                }

                MatchData.Update(match);
                matchSummary = MatchHelper.GetMatchSummary(match);

                return;
            }

            var teamToServe = SetHelper.GetPlayerToServe(matchSummary);
            if (teamToServe == PlayerSide.Left)
            {
                btnLeftScore.BackColor = Color.Yellow;
                btnRightScore.BackColor = SystemColors.Control;
            }
            else if (teamToServe == PlayerSide.Right)
            {
                btnLeftScore.BackColor = SystemColors.Control;
                btnRightScore.BackColor = Color.Yellow;
            }
            else
            {
                btnLeftScore.BackColor = SystemColors.Control;
                btnRightScore.BackColor = SystemColors.Control;
            }
        }

        private void IsSetWinner()
        {
            var setWinner = SetHelper.HasWinner(currentSet, matchSummary.MatchType, secondsPlayedThisSession + matchSummary.SecondsPlayed);

            if (setWinner == PlayerSide.None)
            {
                return;
            }

            btnLeftScore.Enabled = false;
            btnRightScore.Enabled = false;
            setFinished = true;

            if (setWinner == PlayerSide.Left)
            {
                currentSet.SetWinnerId = match.PlayerLeftId;
                if (match.PlayerLeftId2.HasValue)
                {
                    currentSet.SetWinnerId2 = match.PlayerLeftId2;
                }
                btnLeftScore.BackColor = Color.Green;
                return;
            }

            if (setWinner == PlayerSide.Right)
            {
                currentSet.SetWinnerId = match.PlayerRightId;
                if (match.PlayerRightId2.HasValue)
                {
                    currentSet.SetWinnerId2 = match.PlayerRightId2;
                }
                btnRightScore.BackColor = Color.Green;
                return;
            }
        }

        private void BtnStartNewSet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(FormsHelper.GetResourceText("startNextSet"), FormsHelper.GetResourceText("startNextSet"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnStartNewSet.Visible = false;
                btnLeftScore.Text = "0";
                btnLeftScore.Enabled = true;
                btnRightScore.Text = "0";
                btnRightScore.Enabled = true;
                var set = new Set()
                {
                    SetNumber = matchSummary.Sets.Count + 1,
                    MatchId = match.Id,
                    TeamLeftScore = 0,
                    TeamRightScore = 0
                };
                currentSet = SetData.Create(set);
                setFinished = false;
                UpdateMatch();
                btnLeftScore.BackColor = SystemColors.Control;
                btnRightScore.BackColor = SystemColors.Control;
            }
        }

        private void PlayMatch_KeyUp(object sender, KeyEventArgs e)
        {
            var helpKeys = new List<Keys>
            {
                Keys.H,
                Keys.F1
            };

            var playerLeftKeys = new List<Keys>
            {
                Keys.L,
                Keys.Left,
                Keys.LShiftKey,
                Keys.NumPad7
            };

            var playerRightKeys = new List<Keys>
            {
                Keys.R,
                Keys.RShiftKey,
                Keys.Right,
                Keys.NumPad9
            };

            if (helpKeys.Contains(e.KeyCode))
            {
                var helpText = FormsHelper.GetResourceText("help1") + "\r\n";
                helpText += FormsHelper.GetResourceText("help2") + "\r\n\r\n";
                helpText += FormsHelper.GetResourceText("help3") + "\r\n";
                helpText += FormsHelper.GetResourceText("help4") + "\r\n";
                helpText += FormsHelper.GetResourceText("help5") + "\r\n\r\n";
                helpText += FormsHelper.GetResourceText("help6") + "\r\n\r\n";

                MessageBox.Show(helpText, FormsHelper.GetResourceText("help"));
            }

            if (playerLeftKeys.Contains(e.KeyCode))
            {
                UpdateScore(true);
            }

            if (playerRightKeys.Contains(e.KeyCode))
            {
                UpdateScore(false);
            }

            if (e.KeyCode == Keys.Z || e.KeyCode == Keys.NumPad1)
            {
                UpdateScore(true, true);
            }

            if (e.KeyCode == Keys.X || e.KeyCode == Keys.NumPad3)
            {
                UpdateScore(false, true);
            }
        }

        private void PlayMatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            match.PlayTimeSeconds = secondsPlayedThisSession + matchSummary.SecondsPlayed;
            MatchData.Update(match);

            FormsHelper.WriteToBackupLocation();
        }
    }
}
