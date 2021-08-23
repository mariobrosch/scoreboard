using System;
using System.Linq;
using System.Windows.Forms;
using ttManager.Data.data;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.forms
{
    public partial class PlaySinglePlayer : Form
    {
        private readonly SinglePlayerGame _SinglePlayerGame;
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

                lblPreviousRecord.Text = "Highscore: " + bestGame.HighScore.ToString() + " (" + bestGame.MatchDateParsed.ToString("yyyy-MM-dd") + ")";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _SinglePlayerGame.HighScore = Decimal.ToInt32(numScore.Value);
            SinglePlayerGameData.Update(_SinglePlayerGame);
            Dispose();
        }
    }
}
