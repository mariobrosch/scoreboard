using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ttManager.Data.data.requests;
using ttManager.Data.models;

namespace ttManager.forms
{
    public partial class FrmMatchTypes : Form
    {
        private List<MatchType> matchTypes;

        public FrmMatchTypes()
        {
            InitializeComponent();

            LoadMatchTypes();
        }

        private void LoadMatchTypes()
        {
            matchTypes = MatchTypeData.Get().OrderBy(mt => mt.Type).ToList();

            lbMatchTypes.DataSource = matchTypes;
            lbMatchTypes.DisplayMember = "Type";

            if (matchTypes.Count == 0)
            {
                txtId.Text = "Nieuw";
            }
        }

        private void LbMatchTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((MatchType)lbMatchTypes.SelectedItem != null)
            {
                LoadMatchType(((MatchType)lbMatchTypes.SelectedItem));
            }
        }

        private void LoadMatchType(MatchType matchType)
        {
            txtId.Text = matchType.Id.ToString();
            txtType.Text = matchType.Type;
            txtDescription.Text = matchType.Description;
            chkRemoved.Checked = matchType.IsRemoved;
            numNumberOfGamesToWin.Value = matchType.NumberOfGamesToWin;
            numScorePerGameToWin.Value = matchType.ScorePerGameToWin;
            numServiceChangeEveryNumberOfServices.Value = matchType.ServiceChangeEveryNumberOfServices;
            chkTwoPointsDifferenceToWin.Checked = matchType.NeedTwoPointsDifferenceToWin;
            numServiceChangeOnShootOutPer.Value = matchType.ServiceChangeOnShootOutPer;
            chkAvailableForTwoVsTwo.Checked = matchType.IsAvailableForTwoVsTwo;

            btnDelete.Visible = true;

            var matchesWithMatchType = MatchData.GetForMatchType(matchType.Id);
            lblMatchResults.Text = matchesWithMatchType.Count > 0 ? matchesWithMatchType.Count.ToString() + " gespeeld" : "0";
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var matchesForMatchType = MatchData.GetForMatchType(Int32.Parse(txtId.Text));

            if (matchesForMatchType.Count == 0)
            {
                if (MessageBox.Show("Speltype wordt verwijderd. Speltype heeft geen wedstrijd data", "Volledig verwijderen?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MatchTypeData.Delete(txtId.Text);
                    LoadMatchTypes();
                }
            }
            else if (MessageBox.Show("Verwijderen van dit speltype?", "Verwijderen?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var matchType = (MatchType)lbMatchTypes.SelectedItem;
                matchType.IsRemoved = true;
                MatchTypeData.Update(matchType);
                LoadMatchTypes();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "Nieuw")
            {
                var matchType = (MatchType)lbMatchTypes.SelectedItem;
                matchType.Type = txtType.Text;
                matchType.Description = txtDescription.Text;
                matchType.NumberOfGamesToWin = Convert.ToInt32(numNumberOfGamesToWin.Value);
                matchType.ScorePerGameToWin = Convert.ToInt32(numScorePerGameToWin.Value);
                matchType.ServiceChangeEveryNumberOfServices = Convert.ToInt32(numServiceChangeEveryNumberOfServices.Value);
                matchType.NeedTwoPointsDifferenceToWin = chkTwoPointsDifferenceToWin.Checked;
                matchType.ServiceChangeOnShootOutPer = Convert.ToInt32(numServiceChangeOnShootOutPer.Value);
                matchType.IsAvailableForTwoVsTwo = chkAvailableForTwoVsTwo.Checked;

                MatchTypeData.Update(matchType);
            }
            else
            {
                MatchType newMatchType = new MatchType
                {
                    Type = txtType.Text,
                    Description = txtDescription.Text,
                    IsRemoved = chkRemoved.Checked,
                    NumberOfGamesToWin = Convert.ToInt32(numNumberOfGamesToWin.Value),
                    ScorePerGameToWin = Convert.ToInt32(numScorePerGameToWin.Value),
                    ServiceChangeEveryNumberOfServices = Convert.ToInt32(numServiceChangeEveryNumberOfServices.Value),
                    NeedTwoPointsDifferenceToWin = chkTwoPointsDifferenceToWin.Checked,
                    ServiceChangeOnShootOutPer = Convert.ToInt32(numServiceChangeOnShootOutPer.Value),
                    IsAvailableForTwoVsTwo = chkAvailableForTwoVsTwo.Checked
                };

                MatchTypeData.Create(newMatchType);
            }
            LoadMatchTypes();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            lbMatchTypes.ClearSelected();
            txtType.Text = "";
            txtId.Text = "Nieuw";
            txtDescription.Text = "";
            chkRemoved.Checked = false;
            numNumberOfGamesToWin.Value = 1;
            numScorePerGameToWin.Value = 1;
            numServiceChangeEveryNumberOfServices.Value = 1;
            chkTwoPointsDifferenceToWin.Checked = true;
            numServiceChangeOnShootOutPer.Value = 1;
            chkAvailableForTwoVsTwo.Checked = true;
            btnDelete.Visible = false;
        }

        private void ChkDisplayRemoved_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchTypes();
        }
    }
}
