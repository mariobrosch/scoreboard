using System;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data.data.requests;
using Scoreboard.Data.models;

namespace Scoreboard.forms
{
    public partial class CreateSinglePlayerMatch : Form
    {
        public CreateSinglePlayerMatch()
        {
            InitializeComponent();
            LoadData();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var selectedPlayer = (Player)(cboPlayer.SelectedItem);

            var newMatch = new SinglePlayerMatch()
            {
                MatchDateParsed = DateTime.Now,
                PlayerId = selectedPlayer.Id
            };

            var newSavedMatch = SinglePlayerMatchData.Create(newMatch);
            var frmSinglePlayerMatch = new PlaySinglePlayer(newSavedMatch);
            Hide();
            frmSinglePlayerMatch.ShowDialog();
            Show();
        }

        private void LoadData()
        {
            cboPlayer.DataSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayer.DisplayMember = "Name";
        }
    }
}
