using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Linq;
using System.Windows.Forms;

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
            Player selectedPlayer = (Player)cboPlayer.SelectedItem;

            SinglePlayerMatch newMatch = new SinglePlayerMatch()
            {
                MatchDateParsed = DateTime.Now,
                PlayerId = selectedPlayer.Id
            };

            SinglePlayerMatch newSavedMatch = SinglePlayerMatchData.Create(newMatch);
            PlaySinglePlayer frmSinglePlayerMatch = new PlaySinglePlayer(newSavedMatch);
            Hide();
            _ = frmSinglePlayerMatch.ShowDialog();
            Show();
        }

        private void LoadData()
        {
            cboPlayer.DataSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayer.DisplayMember = "Name";
        }
    }
}
