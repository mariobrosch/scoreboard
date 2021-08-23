using System;
using System.Windows.Forms;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.forms
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

            var newGame = new SinglePlayerGame()
            {
                MatchDateParsed = DateTime.Now,
                PlayerId = selectedPlayer.Id
            };

            var newSavedGame = SinglePlayerGameData.Create(newGame);
            var frmSinglePlayerMatch = new PlaySinglePlayer(newSavedGame);
            Hide();
            frmSinglePlayerMatch.ShowDialog();
            Show();
        }

        private void LoadData()
        {
            cboPlayer.DataSource = PlayerData.Get();
            cboPlayer.DisplayMember = "Name";
        }
    }
}
