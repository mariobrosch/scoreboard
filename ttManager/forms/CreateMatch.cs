using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.forms
{
    public partial class CreateMatch : Form
    {
        public CreateMatch()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            cboPlayerLeft.DataSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerLeft2.DataSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerRight.DataSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerRight2.DataSource = PlayerData.Get().OrderBy(p => p.Name).ToList();
            cboPlayerLeft.DisplayMember = "Name";
            cboPlayerLeft2.DisplayMember = "Name";
            cboPlayerRight.DisplayMember = "Name";
            cboPlayerRight2.DisplayMember = "Name";
            cboMatchType.DataSource = MatchTypeData.Get().OrderBy(m => m.Type).ToList();
            cboMatchType.DisplayMember = "Type";
        }

        private bool IsPlayerDouble()
        {
            var playerLeft = (Player)cboPlayerLeft.SelectedItem;
            var playerRight = (Player)cboPlayerRight.SelectedItem;

            if (playerLeft.Id == playerRight.Id)
            {
                return true;
            }

            if (chkTwoVsTwoGame.Checked == false)
            {
                return false;
            }

            var playerLeft2 = (Player)cboPlayerLeft2.SelectedItem;
            var playerRight2 = (Player)cboPlayerRight2.SelectedItem;

            var playerList = new List<int>
            {
                playerLeft.Id,
                playerRight.Id,
                playerLeft2.Id,
                playerRight2.Id
            };

            var result = playerList.GroupBy(id => id)
                        .Select(g => new { Value = g.Key, Count = g.Count() })
                        .OrderByDescending(x => x.Count);

            foreach (var c in result)
            {
                if (c.Count > 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void BtnStartNewGame_Click(object sender, EventArgs e)
        {
            if (IsPlayerDouble())
            {
                MessageBox.Show("Speler kan niet meerdere keren opgesteld worden", "Opstellingsfout");
                return;
            }
            var selectedPlayersForMatch = new List<int>();
            var playerLeft = (Player)cboPlayerLeft.SelectedItem;
            var playerRight = (Player)cboPlayerRight.SelectedItem;
            var matchType = (MatchType)cboMatchType.SelectedItem;

            var newMatch = new Match()
            {
                MatchTypeId = matchType.Id,
                PlayerLeftId = playerLeft.Id,
                PlayerRightId = playerRight.Id
            };

            selectedPlayersForMatch.Add(playerLeft.Id);
            selectedPlayersForMatch.Add(playerRight.Id);

            if (chkTwoVsTwoGame.Checked)
            {
                var playerLeft2 = (Player)cboPlayerLeft2.SelectedItem;
                var playerRight2 = (Player)cboPlayerRight2.SelectedItem;
                newMatch.PlayerLeftId2 = playerLeft2.Id;
                newMatch.PlayerRightId2 = playerRight2.Id;
                selectedPlayersForMatch.Add(playerLeft2.Id);
                selectedPlayersForMatch.Add(playerRight2.Id);
            }

            // Randomize player first serve
            var random = new Random();
            int index = random.Next(selectedPlayersForMatch.Count);
            newMatch.PlayerFirstServiceId = selectedPlayersForMatch[index];

            newMatch.MatchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var m = MatchData.Create(newMatch);

            Hide();
            var frmPlayMatch = new PlayMatch(m);
            frmPlayMatch.ShowDialog();
            Close();
        }

        private void ChkTwoVsTwoGame_CheckedChanged(object sender, EventArgs e)
        {
            lblPlayerLeft2.Visible = chkTwoVsTwoGame.Checked;
            cboPlayerLeft2.Visible = chkTwoVsTwoGame.Checked;
            lblPlayerRight2.Visible = chkTwoVsTwoGame.Checked;
            cboPlayerRight2.Visible = chkTwoVsTwoGame.Checked;
        }

        private void CboMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var matchType = (MatchType)cboMatchType.SelectedItem;
            txtMatchTypeDescription.Text = matchType.Description;
        }
    }
}
