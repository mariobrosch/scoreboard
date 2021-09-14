using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scoreboard.forms
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
            Player playerLeft = (Player)cboPlayerLeft.SelectedItem;
            Player playerRight = (Player)cboPlayerRight.SelectedItem;

            if (playerLeft.Id == playerRight.Id)
            {
                return true;
            }

            if (chkTwoVsTwoMatch.Checked == false)
            {
                return false;
            }

            Player playerLeft2 = (Player)cboPlayerLeft2.SelectedItem;
            Player playerRight2 = (Player)cboPlayerRight2.SelectedItem;

            List<int> playerList = new List<int>
            {
                playerLeft.Id,
                playerRight.Id,
                playerLeft2.Id,
                playerRight2.Id
            };

            IOrderedEnumerable<(int Value, int Count)> result = playerList.GroupBy(id => id)
                        .Select(g => (Value: g.Key, Count: g.Count()))
                        .OrderByDescending(x => x.Count);

            foreach ((int Value, int Count) in result)
            {
                if (Count > 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void BtnStartNewSet_Click(object sender, EventArgs e)
        {
            if (IsPlayerDouble())
            {
                _ = MessageBox.Show(FormsHelper.GetResourceText("setupErrorDescription"), FormsHelper.GetResourceText("setupErrorTitle"));
                return;
            }
            List<int> selectedPlayersForMatch = new List<int>();
            Player playerLeft = (Player)cboPlayerLeft.SelectedItem;
            Player playerRight = (Player)cboPlayerRight.SelectedItem;
            MatchType matchType = (MatchType)cboMatchType.SelectedItem;

            Match newMatch = new Match()
            {
                MatchTypeId = matchType.Id,
                PlayerLeftId = playerLeft.Id,
                PlayerRightId = playerRight.Id
            };

            selectedPlayersForMatch.Add(playerLeft.Id);
            selectedPlayersForMatch.Add(playerRight.Id);

            if (chkTwoVsTwoMatch.Checked)
            {
                Player playerLeft2 = (Player)cboPlayerLeft2.SelectedItem;
                Player playerRight2 = (Player)cboPlayerRight2.SelectedItem;
                newMatch.PlayerLeftId2 = playerLeft2.Id;
                newMatch.PlayerRightId2 = playerRight2.Id;
                selectedPlayersForMatch.Add(playerLeft2.Id);
                selectedPlayersForMatch.Add(playerRight2.Id);
            }

            // Randomize player first serve
            Random random = new Random();
            int index = random.Next(selectedPlayersForMatch.Count);
            newMatch.PlayerFirstServiceId = selectedPlayersForMatch[index];

            newMatch.MatchDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Match m = MatchData.Create(newMatch);

            Hide();
            PlayMatch frmPlayMatch = new PlayMatch(m);
            _ = frmPlayMatch.ShowDialog();
            Close();
        }

        private void ChkTwoVsTwoMatch_CheckedChanged(object sender, EventArgs e)
        {
            lblPlayerLeft2.Visible = chkTwoVsTwoMatch.Checked;
            cboPlayerLeft2.Visible = chkTwoVsTwoMatch.Checked;
            lblPlayerRight2.Visible = chkTwoVsTwoMatch.Checked;
            cboPlayerRight2.Visible = chkTwoVsTwoMatch.Checked;
        }

        private void CboMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchType matchType = (MatchType)cboMatchType.SelectedItem;
            txtMatchTypeDescription.Text = matchType.Description;
        }
    }
}
