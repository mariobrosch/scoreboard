using Scoreboard.DataCore.Data;
using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Scoreboard.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for PlaySinglePlayer.xaml
    /// </summary>
    public partial class PlaySinglePlayer : Window
    {
        private readonly SinglePlayerMatch _SinglePlayerMatch;
        private readonly int highScore;

        public PlaySinglePlayer(SinglePlayerMatch singlePlayerMatch)
        {
            _SinglePlayerMatch = singlePlayerMatch;

            InitializeComponent();

            WpfHelper.SetLanguageResourceDictionary(this, MethodBase.GetCurrentMethod().DeclaringType.Name);

            FilterObject filterObject = new()
            {
                Column = "PlayerId",
                Value = _SinglePlayerMatch.PlayerId.ToString()
            };
            List<SinglePlayerMatch> allPlayedMatches = SinglePlayerMatchData.Get(filterObject);
            if (allPlayedMatches.Count > 1)
            {
                allPlayedMatches = allPlayedMatches.OrderBy(x => x.HighScore).ToList();
                SinglePlayerMatch bestMatch = allPlayedMatches[allPlayedMatches.Count - 1];
                highScore = bestMatch.HighScore;
                lblPreviousRecord.Text = WpfHelper.GetResourceText("highscore") + ": " + highScore.ToString() + " (" + bestMatch.MatchDateParsed.ToString("yyyy-MM-dd") + ")";
            }
            numScore.Select(0, numScore.Text.Length);
            numScore.Focus();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int score = Convert.ToInt32(numScore.Text);

            if (score > highScore)
            {
                WpfHelper.PlaySound(SoundTypes.Applause);
            }

            _SinglePlayerMatch.HighScore = score;
            _ = SinglePlayerMatchData.Update(_SinglePlayerMatch);
            Close();
        }

        private void NumScore_KeyUp(object sender, KeyEventArgs e)
        {
            _ = int.TryParse(numScore.Text.Replace("+", "").Replace("-", ""), out int score);

            if (e.Key == Key.Subtract)
            {
                if (score < 0)
                {
                    numScore.Text = (score * -1).ToString();
                }
                numScore.Text = (score - 1).ToString();
            }
            if (e.Key == Key.Add)
            {
                numScore.Text = (score + 1).ToString();
            }
            _ = numScore.Focus();
        }
    }
}
