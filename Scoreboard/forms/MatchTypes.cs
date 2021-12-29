using Scoreboard.DataCore.Data.Requests;
using Scoreboard.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scoreboard.forms
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
                txtId.Text = FormsHelper.GetResourceText("new");
            }
        }

        private void LbMatchTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((MatchType)lbMatchTypes.SelectedItem != null)
            {
                LoadMatchType((MatchType)lbMatchTypes.SelectedItem);
            }
            SetFieldsEnabled();
        }

        private void LoadMatchType(MatchType matchType)
        {
            txtId.Text = matchType.Id.ToString();
            txtType.Text = matchType.Type;
            txtDescription.Text = matchType.Description;
            chkRemoved.Checked = matchType.IsRemoved;
            numNumberOfSetsToWin.Value = matchType.NumberOfSetsToWin;
            numScorePerSetToWin.Value = matchType.ScorePerSetToWin;
            numServiceChangeEveryNumberOfServices.Value = matchType.ServiceChangeEveryNumberOfServices;
            chkTwoPointsDifferenceToWin.Checked = matchType.NeedTwoPointsDifferenceToWin;
            numServiceChangeOnShootOutPer.Value = matchType.ServiceChangeOnShootOutPer;
            chkAvailableForTwoVsTwo.Checked = matchType.IsAvailableForTwoVsTwo;
            chkTimedMatch.Checked = matchType.IsTimedMatch;
            numTimeOfMatch.Value = matchType.MatchTime ?? 1;
            btnDelete.Visible = true;

            List<Match> matchesWithMatchType = MatchData.GetForMatchType(matchType.Id);
            lblMatchResults.Text = matchesWithMatchType.Count > 0 ? matchesWithMatchType.Count.ToString() + " " + FormsHelper.GetResourceText("played") : "0";
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            List<Match> matchesForMatchType = MatchData.GetForMatchType(int.Parse(txtId.Text));

            if (matchesForMatchType.Count == 0)
            {
                if (MessageBox.Show(FormsHelper.GetResourceText("matchTypeRemovedDescription"), FormsHelper.GetResourceText("completeRemove"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _ = MatchTypeData.Delete(txtId.Text);
                    LoadMatchTypes();
                }
            }
            else if (MessageBox.Show(FormsHelper.GetResourceText("RemoveMatchType"), FormsHelper.GetResourceText("remove"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MatchType matchType = (MatchType)lbMatchTypes.SelectedItem;
                matchType.IsRemoved = true;
                _ = MatchTypeData.Update(matchType);
                LoadMatchTypes();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != FormsHelper.GetResourceText("new"))
            {
                MatchType matchType = (MatchType)lbMatchTypes.SelectedItem;
                matchType.Type = txtType.Text;
                matchType.Description = txtDescription.Text;
                matchType.NumberOfSetsToWin = Convert.ToInt32(numNumberOfSetsToWin.Value);
                matchType.ScorePerSetToWin = Convert.ToInt32(numScorePerSetToWin.Value);
                matchType.ServiceChangeEveryNumberOfServices = Convert.ToInt32(numServiceChangeEveryNumberOfServices.Value);
                matchType.NeedTwoPointsDifferenceToWin = chkTwoPointsDifferenceToWin.Checked;
                matchType.ServiceChangeOnShootOutPer = Convert.ToInt32(numServiceChangeOnShootOutPer.Value);
                matchType.IsAvailableForTwoVsTwo = chkAvailableForTwoVsTwo.Checked;
                matchType.IsTimedMatch = chkTimedMatch.Checked;
                matchType.MatchTime = Convert.ToInt32(numTimeOfMatch.Value);

                _ = MatchTypeData.Update(matchType);
            }
            else
            {
                MatchType newMatchType = new MatchType
                {
                    Type = txtType.Text,
                    Description = txtDescription.Text,
                    IsRemoved = chkRemoved.Checked,
                    NumberOfSetsToWin = Convert.ToInt32(numNumberOfSetsToWin.Value),
                    ScorePerSetToWin = Convert.ToInt32(numScorePerSetToWin.Value),
                    ServiceChangeEveryNumberOfServices = Convert.ToInt32(numServiceChangeEveryNumberOfServices.Value),
                    NeedTwoPointsDifferenceToWin = chkTwoPointsDifferenceToWin.Checked,
                    ServiceChangeOnShootOutPer = Convert.ToInt32(numServiceChangeOnShootOutPer.Value),
                    IsAvailableForTwoVsTwo = chkAvailableForTwoVsTwo.Checked,
                    IsTimedMatch = chkTimedMatch.Checked,
                    MatchTime = Convert.ToInt32(numTimeOfMatch.Value)
                };

                _ = MatchTypeData.Create(newMatchType);
            }
            LoadMatchTypes();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            lbMatchTypes.ClearSelected();
            txtType.Text = "";
            txtId.Text = FormsHelper.GetResourceText("new");
            txtDescription.Text = "";
            chkRemoved.Checked = false;
            numNumberOfSetsToWin.Value = 1;
            numScorePerSetToWin.Value = 1;
            numServiceChangeEveryNumberOfServices.Value = 1;
            chkTwoPointsDifferenceToWin.Checked = true;
            numServiceChangeOnShootOutPer.Value = 1;
            chkAvailableForTwoVsTwo.Checked = true;
            btnDelete.Visible = false;
            numTimeOfMatch.Value = 1;
            lblMatchResults.Text = "-";
            SetFieldsEnabled();
        }

        private void ChkDisplayRemoved_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchTypes();
        }

        private void ChkTimedMatch_CheckedChanged(object sender, EventArgs e)
        {
            SetFieldsEnabled();
        }

        private void SetFieldsEnabled()
        {
            numNumberOfSetsToWin.Enabled = !chkTimedMatch.Checked;
            numScorePerSetToWin.Enabled = !chkTimedMatch.Checked;
            chkTwoPointsDifferenceToWin.Enabled = !chkTimedMatch.Checked;
            numServiceChangeOnShootOutPer.Enabled = !chkTimedMatch.Checked;
            numTimeOfMatch.Enabled = chkTimedMatch.Checked;
        }
    }
}
