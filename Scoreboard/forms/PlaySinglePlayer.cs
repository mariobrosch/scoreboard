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
        private readonly SinglePlayerMatch _SinglePlayerMatch;
        private readonly int highScore;
        public PlaySinglePlayer(SinglePlayerMatch singlePlayerMatch)
        {
            _SinglePlayerMatch = singlePlayerMatch;
            InitializeComponent();

            var filterObject = new FilterObject()
            {
                Column = "PlayerId",
                Value = _SinglePlayerMatch.PlayerId.ToString()
            };
            var allPlayedMatches = SinglePlayerMatchData.Get(filterObject);
            if (allPlayedMatches.Count > 1)
            {
                allPlayedMatches = allPlayedMatches.OrderBy(x => x.HighScore).ToList();
                var bestMatch = allPlayedMatches[allPlayedMatches.Count - 1];
                highScore = bestMatch.HighScore;
                lblPreviousRecord.Text = FormsHelper.GetResourceText("highscore") + ": " + highScore.ToString() + " (" + bestMatch.MatchDateParsed.ToString("yyyy-MM-dd") + ")";
            }
            numScore.Select(0, numScore.Value.ToString().Length);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (numScore.Value > highScore)
            {
                FormsHelper.PlaySound(SoundTypes.Applause);
            }

            _SinglePlayerMatch.HighScore = Decimal.ToInt32(numScore.Value);
            SinglePlayerMatchData.Update(_SinglePlayerMatch);
            Dispose();
        }

        private void PlaySinglePlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                if (numScore.Value < 0)
                {
                    numScore.Value *= -1;
                }
                numScore.Value--;
            }
            if (e.KeyCode == Keys.Add)
            {
                numScore.Value++;
            }
            numScore.Focus();
        }
    }
}
