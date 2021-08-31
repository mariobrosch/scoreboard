using System;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data.data;
using Scoreboard.Data.data.requests;
using Scoreboard.Data.models;

namespace Scoreboard.forms
{
    public partial class PlaySinglePlayer : Form
    {
        private readonly SinglePlayerGame _SinglePlayerGame;
        private readonly int highScore;
        public PlaySinglePlayer(SinglePlayerGame singlePlayerGame)
        {
            _SinglePlayerGame = singlePlayerGame;
            InitializeComponent();

            var filterObject = new FilterObject()
            {
                Column = "PlayerId",
                Value = _SinglePlayerGame.PlayerId.ToString()
            };
            var allPlayedGames = SinglePlayerGameData.Get(filterObject);
            if (allPlayedGames.Count > 1)
            {
                allPlayedGames = allPlayedGames.OrderBy(x => x.HighScore).ToList();
                var bestGame = allPlayedGames[allPlayedGames.Count - 1];
                highScore = bestGame.HighScore;
                lblPreviousRecord.Text = FormsHelper.GetResourceText("highscore") + ": " + highScore.ToString() + " (" + bestGame.MatchDateParsed.ToString("yyyy-MM-dd") + ")";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (numScore.Value > highScore)
            {
                FormsHelper.PlaySound(SoundTypes.Applause);
            }

            _SinglePlayerGame.HighScore = Decimal.ToInt32(numScore.Value);
            SinglePlayerGameData.Update(_SinglePlayerGame);
            Dispose();
        }
    }
}
