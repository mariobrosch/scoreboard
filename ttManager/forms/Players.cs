using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.forms
{
    public partial class FrmPlayers : Form
    {
        private List<Player> players;

        public FrmPlayers()
        {
            InitializeComponent();

            LoadPlayers();
        }

        private void LoadPlayers()
        {
            players = PlayerData.Get(chkDisplayRemoved.Checked)?.OrderBy(p => p.Name).ToList();

            lbPlayers.DataSource = players;
            lbPlayers.DisplayMember = "Name";

            if(players.Count == 0)
            {
                txtId.Text = "Nieuw";
            }
        }

        private void LbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Player)lbPlayers.SelectedItem != null)
            {
                LoadPlayer(((Player)lbPlayers.SelectedItem));
            }
        }

        private void LoadPlayer(Player player)
        {
            txtId.Text = player.Id.ToString();
            txtName.Text = player.Name;
            txtPhoto.Text = player.Photo;
            chkEnabled.Checked = player.IsEnabled;
            chkRemoved.Checked = player.IsRemoved;

            btnDelete.Visible = true;

            var singlePlayerMatches = SinglePlayerGameData.GetForPlayer(player.Id);
            if (singlePlayerMatches.Count > 0)
            {
                var bestGame = singlePlayerMatches.OrderBy(x => x.HighScore).Last();
                lblSinglePlayerMatches.Text = singlePlayerMatches.Count + " gespeeld waarvan de hoogste score op " + bestGame.MatchDateParsed.ToString("yyyy-MM-dd") + " met als score " + bestGame.HighScore.ToString();
            } else
            {
                lblSinglePlayerMatches.Text = "-";
            }

            var matchesForPlayer = MatchData.GetForPlayer(player.Id);
            var matchesWon = matchesForPlayer.Where(m => m.WinnerId == player.Id).ToList().Count;
            lblMatchResults.Text = matchesForPlayer.Count > 0 ? matchesForPlayer.Count.ToString() + " gespeeld en " + matchesWon.ToString() + " gewonnen" : "0";
        }

        private void TxtPhoto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhoto.Text))
            {
                pbPhoto.Load(txtPhoto.Text);
            }
            else
            {
                pbPhoto.Image = null;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var matchesForPlayer = MatchData.GetForPlayer(Int32.Parse(txtId.Text));

            if (matchesForPlayer.Count == 0)
            {
                if (MessageBox.Show("Speler wordt verwijderd. Speler heeft geen wedstrijd data", "Volledig verwijderen?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PlayerData.Delete(txtId.Text);
                    LoadPlayers();
                }
            }
            else if (MessageBox.Show("Verwijderen van deze speler?", "Verwijderen?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var player = (Player)lbPlayers.SelectedItem;
                player.IsRemoved = true;
                PlayerData.Update(player);
                LoadPlayers();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "Nieuw")
            {
                var player = (Player)lbPlayers.SelectedItem;
                if (player == null)
                {
                    return;
                }
                player.IsEnabled = chkEnabled.Checked;
                player.Name = txtName.Text;
                player.Photo = txtPhoto.Text;

                PlayerData.Update(player);
            }
            else
            {
                Player newPlayer = new Player
                {
                    IsEnabled = chkEnabled.Checked,
                    Name = txtName.Text,
                    Photo = txtPhoto.Text,
                    IsRemoved = chkRemoved.Checked
                };

                PlayerData.Create(newPlayer);
            }
            LoadPlayers();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            lbPlayers.ClearSelected();
            txtName.Text = "";
            txtId.Text = "Nieuw";
            txtPhoto.Text = "";
            pbPhoto.Image = null;
            chkEnabled.Checked = true;
            btnDelete.Visible = false;
            lblSinglePlayerMatches.Text = "";
            lblPlayedMatches.Text = "";
        }

        private void ChkDisplayRemoved_CheckedChanged(object sender, EventArgs e)
        {
            LoadPlayers();
        }
    }
}
