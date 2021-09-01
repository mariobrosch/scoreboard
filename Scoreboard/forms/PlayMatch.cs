using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Game currentGame;
        private bool gameFinished = false;

        public PlayMatch(Match m)
        {
            InitializeComponent();

            match = m;
            if (match.Id == 0)
            {
                Close();
            }
            matchSummary = MatchHelper.GetMatchSummary(match);
            if (matchSummary.Games.Count == 0)
            {
                currentGame = new Game
                {
                    GameNumber = 1,
                    MatchId = match.Id
                };
                currentGame = GameData.Create(currentGame);
            }
            else
            {
                currentGame = matchSummary.Games[matchSummary.Games.Count - 1];
            }
            btnLeftScore.Text = currentGame.TeamLeftScore.ToString();
            btnRightScore.Text = currentGame.TeamRightScore.ToString();
            FillTopInfo();
            IsGameWinner();
            UpdateMatch();
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
            if (currentGame.GameWinnerId.HasValue)
            {
                MessageBox.Show(FormsHelper.GetResourceText("setPlayedErrorDesc"));
            } else if (matchSummary.Winner.HasValue) {
                MessageBox.Show(FormsHelper.GetResourceText("matchPlayedErrorDesc"));
            } else if (isForLeft)
            {
                if (negativeScore)
                {
                    if (currentGame.TeamLeftScore > 0)
                    {
                        currentGame.TeamLeftScore--;
                    }
                }
                else
                {
                    currentGame.TeamLeftScore++;
                }
                btnLeftScore.Text = currentGame.TeamLeftScore.ToString();
            }
            else
            {
                if (negativeScore)
                {
                    if (currentGame.TeamRightScore > 0)
                    {
                        currentGame.TeamRightScore--;
                    }
                }
                else
                {
                    currentGame.TeamRightScore++;
                }
                btnRightScore.Text = currentGame.TeamRightScore.ToString();
            }
            IsGameWinner();
            GameData.Update(currentGame);
            UpdateMatch();
            FillTopInfo();
        }

        private void UpdateMatch()
        {
            matchSummary = MatchHelper.GetMatchSummary(match);

            if (gameFinished)
            {
                var matchWinner = MatchHelper.HasMatchWinner(matchSummary);

                if (matchWinner == PlayerSide.None)
                {
                    // No update needed, all data is in the games, just refetch the summary
                    matchSummary = MatchHelper.GetMatchSummary(match);
                    btnStartNewGame.Visible = true;
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

            var teamToServe = GameHelper.GetPlayerToServe(matchSummary);
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

        private void IsGameWinner()
        {
            var gameWinner = GameHelper.HasWinner(currentGame, matchSummary.MatchType);

            if (gameWinner == PlayerSide.None)
            {
                return;
            }

            btnLeftScore.Enabled = false;
            btnRightScore.Enabled = false;
            gameFinished = true;

            if (gameWinner == PlayerSide.Left)
            {
                currentGame.GameWinnerId = match.PlayerLeftId;
                if (match.PlayerLeftId2.HasValue)
                {
                    currentGame.GameWinnerId2 = match.PlayerLeftId2;
                }
                btnLeftScore.BackColor = Color.Green;
                return;
            }

            if (gameWinner == PlayerSide.Right)
            {
                currentGame.GameWinnerId = match.PlayerRightId;
                if (match.PlayerRightId2.HasValue)
                {
                    currentGame.GameWinnerId2 = match.PlayerRightId2;
                }
                btnRightScore.BackColor = Color.Green;
                return;
            }
        }

        private void BtnStartNewGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(FormsHelper.GetResourceText("startNextSet"), FormsHelper.GetResourceText("startNextSet"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnStartNewGame.Visible = false;
                btnLeftScore.Text = "0";
                btnLeftScore.Enabled = true;
                btnRightScore.Text = "0";
                btnRightScore.Enabled = true;
                var game = new Game()
                {
                    GameNumber = matchSummary.Games.Count + 1,
                    MatchId = match.Id,
                    TeamLeftScore = 0,
                    TeamRightScore = 0
                };
                currentGame = GameData.Create(game);
                gameFinished = false;
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
                var helpText = FormsHelper.GetResourceText("help1")+ "\r\n";
                helpText += FormsHelper.GetResourceText("help2") + "\r\n\r\n";
                helpText += FormsHelper.GetResourceText("help3") + "\r\n";
                helpText += FormsHelper.GetResourceText("help4") + "\r\n";
                helpText += FormsHelper.GetResourceText("help5")+  "\r\n\r\n";
                helpText += FormsHelper.GetResourceText("help6") + "\r\n\r\n";

                MessageBox.Show(helpText,  FormsHelper.GetResourceText("help"));
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
            FormsHelper.WriteToBackupLocation();
        }
    }
}
