using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ttManager.Data.data.requests;
using ttManager.Data.enums;
using ttManager.Data.Helpers;
using ttManager.Data.models;

namespace ttManager.forms
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
            if (isForLeft)
            {
                if (negativeScore)
                {
                    if (currentGame.GameWinnerId.HasValue)
                    {
                        MessageBox.Show("Set is al gespeeld, punten aftrekken niet mogelijk");
                    }
                    else
                    {
                        if (currentGame.TeamLeftScore > 0)
                        {
                            currentGame.TeamLeftScore--;
                        }
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
                    if (currentGame.GameWinnerId.HasValue)
                    {
                        MessageBox.Show("Set is al gespeeld, punten aftrekken niet mogelijk");
                    }
                    else
                    {
                        if (currentGame.TeamRightScore > 0)
                        {
                            currentGame.TeamRightScore--;
                        }
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
                    match.WinnerId = match.PlayerLeftId;
                    match.WinnerId2 = match.PlayerLeftId2;
                    txtLeft.BackColor = Color.Green;
                    txtWinner.Text = "Team '" + matchSummary.TeamLeft + "' heeft gewonnen";
                    txtWinner.Visible = true;
                    txtLeft.SelectionLength = 0;
                    txtWinner.SelectionLength = 0;
                }

                if (matchWinner == PlayerSide.Right)
                {
                    match.WinnerId = match.PlayerRightId;
                    match.WinnerId2 = match.PlayerRightId2;
                    txtRight.BackColor = Color.Green;
                    txtRight.SelectionLength = 0;
                    txtWinner.Text = "Team '" + matchSummary.TeamRight + "' heeft gewonnen";
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
            if (MessageBox.Show("Start de volgende set?", "Volgende set starten?", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                Keys.NumPad0,
                Keys.NumPad1,
                Keys.NumPad4,
                Keys.NumPad7
            };

            var playerRightKeys = new List<Keys>
            {
                Keys.R,
                Keys.RShiftKey,
                Keys.Right,
                Keys.NumPad3,
                Keys.NumPad6,
                Keys.NumPad9
            };

            if (helpKeys.Contains(e.KeyCode))
            {
                var helpText = "Gebruik je toetsenbord om score op te hogen, scores kunnen niet terug gedraaid worden.\r\nVoor linkerteam gelden de volgende sneltoetsen:\r\n";
                helpText += "L, Linker shift, Links, Numpad 0, 1, 4 en 7\r\n\r\n";
                helpText += "Voor het rechterteam:\r\n";
                helpText += "R, Rechter shift, Rechts, Numpad 3, 6 en 9\r\n";
                helpText += "Z voor minpunt linker team\r\n\r\n";
                helpText += "X voor minpunt rechterteam\r\n\r\n";

                MessageBox.Show(helpText, "Help!");
            }

            if (playerLeftKeys.Contains(e.KeyCode))
            {
                UpdateScore(true);
            }

            if (playerRightKeys.Contains(e.KeyCode))
            {
                UpdateScore(false);
            }

            if (e.KeyCode == Keys.Z)
            {
                UpdateScore(true, true);
            }

            if (e.KeyCode == Keys.X)
            {
                UpdateScore(false, true);
            }
        }

        private void PlayMatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            string backupLocation = ConfigurationManager.AppSettings["backupLocation"];
            string localStoragePath = ConfigurationManager.AppSettings["localStoragePath"];
            string backupDrive = ConfigurationManager.AppSettings["backupDrive"];

            if (Directory.Exists(backupDrive))
            {
                if (!Directory.Exists(backupLocation))
                {
                    Directory.CreateDirectory(backupLocation);
                }

                foreach (string file in Directory.GetFiles(localStoragePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(file, file.Replace(localStoragePath, backupLocation), true);
                }
            }
        }
    }
}
