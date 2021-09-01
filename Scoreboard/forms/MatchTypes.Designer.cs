
namespace Scoreboard.forms
{
    partial class FrmMatchTypes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatchTypes));
            this.lbMatchTypes = new System.Windows.Forms.ListBox();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.numTimeOfMatch = new System.Windows.Forms.NumericUpDown();
            this.lblTimeOfMatch = new System.Windows.Forms.Label();
            this.chkTimedMatch = new System.Windows.Forms.CheckBox();
            this.lblTimedMatch = new System.Windows.Forms.Label();
            this.numServiceChangeOnShootOutPer = new System.Windows.Forms.NumericUpDown();
            this.chkTwoPointsDifferenceToWin = new System.Windows.Forms.CheckBox();
            this.lblAvailableForTwoVsTwo = new System.Windows.Forms.Label();
            this.chkAvailableForTwoVsTwo = new System.Windows.Forms.CheckBox();
            this.lblServiceChangeOnShootOutPer = new System.Windows.Forms.Label();
            this.lblTwoPointsDifferenceToWin = new System.Windows.Forms.Label();
            this.numServiceChangeEveryNumberOfServices = new System.Windows.Forms.NumericUpDown();
            this.lblServiceChangeEveryNumberOfServices = new System.Windows.Forms.Label();
            this.numScorePerSetToWin = new System.Windows.Forms.NumericUpDown();
            this.lblScorePerSetToWin = new System.Windows.Forms.Label();
            this.numNumberOfSetsToWin = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfSetsToWin = new System.Windows.Forms.Label();
            this.lblMatchResults = new System.Windows.Forms.Label();
            this.lblPlayedMatches = new System.Windows.Forms.Label();
            this.lblRemoved = new System.Windows.Forms.Label();
            this.chkRemoved = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlPlayerlist = new System.Windows.Forms.Panel();
            this.chkDisplayRemoved = new System.Windows.Forms.CheckBox();
            this.pnlPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOfMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeOnShootOutPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeEveryNumberOfServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScorePerSetToWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfSetsToWin)).BeginInit();
            this.pnlPlayerlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMatchTypes
            // 
            resources.ApplyResources(this.lbMatchTypes, "lbMatchTypes");
            this.lbMatchTypes.FormattingEnabled = true;
            this.lbMatchTypes.Name = "lbMatchTypes";
            this.lbMatchTypes.SelectedIndexChanged += new System.EventHandler(this.LbMatchTypes_SelectedIndexChanged);
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.Controls.Add(this.numTimeOfMatch);
            this.pnlPlayer.Controls.Add(this.lblTimeOfMatch);
            this.pnlPlayer.Controls.Add(this.chkTimedMatch);
            this.pnlPlayer.Controls.Add(this.lblTimedMatch);
            this.pnlPlayer.Controls.Add(this.numServiceChangeOnShootOutPer);
            this.pnlPlayer.Controls.Add(this.chkTwoPointsDifferenceToWin);
            this.pnlPlayer.Controls.Add(this.lblAvailableForTwoVsTwo);
            this.pnlPlayer.Controls.Add(this.chkAvailableForTwoVsTwo);
            this.pnlPlayer.Controls.Add(this.lblServiceChangeOnShootOutPer);
            this.pnlPlayer.Controls.Add(this.lblTwoPointsDifferenceToWin);
            this.pnlPlayer.Controls.Add(this.numServiceChangeEveryNumberOfServices);
            this.pnlPlayer.Controls.Add(this.lblServiceChangeEveryNumberOfServices);
            this.pnlPlayer.Controls.Add(this.numScorePerSetToWin);
            this.pnlPlayer.Controls.Add(this.lblScorePerSetToWin);
            this.pnlPlayer.Controls.Add(this.numNumberOfSetsToWin);
            this.pnlPlayer.Controls.Add(this.lblNumberOfSetsToWin);
            this.pnlPlayer.Controls.Add(this.lblMatchResults);
            this.pnlPlayer.Controls.Add(this.lblPlayedMatches);
            this.pnlPlayer.Controls.Add(this.lblRemoved);
            this.pnlPlayer.Controls.Add(this.chkRemoved);
            this.pnlPlayer.Controls.Add(this.lblDescription);
            this.pnlPlayer.Controls.Add(this.txtDescription);
            this.pnlPlayer.Controls.Add(this.lblType);
            this.pnlPlayer.Controls.Add(this.txtType);
            this.pnlPlayer.Controls.Add(this.txtId);
            this.pnlPlayer.Controls.Add(this.lblId);
            this.pnlPlayer.Controls.Add(this.btnDelete);
            this.pnlPlayer.Controls.Add(this.btnSave);
            resources.ApplyResources(this.pnlPlayer, "pnlPlayer");
            this.pnlPlayer.Name = "pnlPlayer";
            // 
            // numTimeOfMatch
            // 
            resources.ApplyResources(this.numTimeOfMatch, "numTimeOfMatch");
            this.numTimeOfMatch.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeOfMatch.Name = "numTimeOfMatch";
            this.numTimeOfMatch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTimeOfMatch
            // 
            resources.ApplyResources(this.lblTimeOfMatch, "lblTimeOfMatch");
            this.lblTimeOfMatch.Name = "lblTimeOfMatch";
            // 
            // chkTimedMatch
            // 
            resources.ApplyResources(this.chkTimedMatch, "chkTimedMatch");
            this.chkTimedMatch.Name = "chkTimedMatch";
            this.chkTimedMatch.UseVisualStyleBackColor = true;
            this.chkTimedMatch.CheckedChanged += new System.EventHandler(this.ChkTimedMatch_CheckedChanged);
            // 
            // lblTimedMatch
            // 
            resources.ApplyResources(this.lblTimedMatch, "lblTimedMatch");
            this.lblTimedMatch.Name = "lblTimedMatch";
            // 
            // numServiceChangeOnShootOutPer
            // 
            resources.ApplyResources(this.numServiceChangeOnShootOutPer, "numServiceChangeOnShootOutPer");
            this.numServiceChangeOnShootOutPer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numServiceChangeOnShootOutPer.Name = "numServiceChangeOnShootOutPer";
            this.numServiceChangeOnShootOutPer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkTwoPointsDifferenceToWin
            // 
            resources.ApplyResources(this.chkTwoPointsDifferenceToWin, "chkTwoPointsDifferenceToWin");
            this.chkTwoPointsDifferenceToWin.Name = "chkTwoPointsDifferenceToWin";
            this.chkTwoPointsDifferenceToWin.UseVisualStyleBackColor = true;
            // 
            // lblAvailableForTwoVsTwo
            // 
            resources.ApplyResources(this.lblAvailableForTwoVsTwo, "lblAvailableForTwoVsTwo");
            this.lblAvailableForTwoVsTwo.Name = "lblAvailableForTwoVsTwo";
            // 
            // chkAvailableForTwoVsTwo
            // 
            resources.ApplyResources(this.chkAvailableForTwoVsTwo, "chkAvailableForTwoVsTwo");
            this.chkAvailableForTwoVsTwo.Name = "chkAvailableForTwoVsTwo";
            this.chkAvailableForTwoVsTwo.UseVisualStyleBackColor = true;
            // 
            // lblServiceChangeOnShootOutPer
            // 
            resources.ApplyResources(this.lblServiceChangeOnShootOutPer, "lblServiceChangeOnShootOutPer");
            this.lblServiceChangeOnShootOutPer.Name = "lblServiceChangeOnShootOutPer";
            // 
            // lblTwoPointsDifferenceToWin
            // 
            resources.ApplyResources(this.lblTwoPointsDifferenceToWin, "lblTwoPointsDifferenceToWin");
            this.lblTwoPointsDifferenceToWin.Name = "lblTwoPointsDifferenceToWin";
            // 
            // numServiceChangeEveryNumberOfServices
            // 
            resources.ApplyResources(this.numServiceChangeEveryNumberOfServices, "numServiceChangeEveryNumberOfServices");
            this.numServiceChangeEveryNumberOfServices.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numServiceChangeEveryNumberOfServices.Name = "numServiceChangeEveryNumberOfServices";
            this.numServiceChangeEveryNumberOfServices.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblServiceChangeEveryNumberOfServices
            // 
            resources.ApplyResources(this.lblServiceChangeEveryNumberOfServices, "lblServiceChangeEveryNumberOfServices");
            this.lblServiceChangeEveryNumberOfServices.Name = "lblServiceChangeEveryNumberOfServices";
            // 
            // numScorePerSetToWin
            // 
            resources.ApplyResources(this.numScorePerSetToWin, "numScorePerSetToWin");
            this.numScorePerSetToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScorePerSetToWin.Name = "numScorePerSetToWin";
            this.numScorePerSetToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblScorePerSetToWin
            // 
            resources.ApplyResources(this.lblScorePerSetToWin, "lblScorePerSetToWin");
            this.lblScorePerSetToWin.Name = "lblScorePerSetToWin";
            // 
            // numNumberOfSetsToWin
            // 
            resources.ApplyResources(this.numNumberOfSetsToWin, "numNumberOfSetsToWin");
            this.numNumberOfSetsToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfSetsToWin.Name = "numNumberOfSetsToWin";
            this.numNumberOfSetsToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberOfSetsToWin
            // 
            resources.ApplyResources(this.lblNumberOfSetsToWin, "lblNumberOfSetsToWin");
            this.lblNumberOfSetsToWin.Name = "lblNumberOfSetsToWin";
            // 
            // lblMatchResults
            // 
            resources.ApplyResources(this.lblMatchResults, "lblMatchResults");
            this.lblMatchResults.Name = "lblMatchResults";
            // 
            // lblPlayedMatches
            // 
            resources.ApplyResources(this.lblPlayedMatches, "lblPlayedMatches");
            this.lblPlayedMatches.Name = "lblPlayedMatches";
            // 
            // lblRemoved
            // 
            resources.ApplyResources(this.lblRemoved, "lblRemoved");
            this.lblRemoved.Name = "lblRemoved";
            // 
            // chkRemoved
            // 
            resources.ApplyResources(this.chkRemoved, "chkRemoved");
            this.chkRemoved.Name = "chkRemoved";
            this.chkRemoved.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // txtType
            // 
            resources.ApplyResources(this.txtType, "txtType");
            this.txtType.Name = "txtType";
            // 
            // txtId
            // 
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            // 
            // lblId
            // 
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.Name = "lblId";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // pnlPlayerlist
            // 
            this.pnlPlayerlist.Controls.Add(this.chkDisplayRemoved);
            this.pnlPlayerlist.Controls.Add(this.btnNew);
            this.pnlPlayerlist.Controls.Add(this.lbMatchTypes);
            resources.ApplyResources(this.pnlPlayerlist, "pnlPlayerlist");
            this.pnlPlayerlist.Name = "pnlPlayerlist";
            // 
            // chkDisplayRemoved
            // 
            resources.ApplyResources(this.chkDisplayRemoved, "chkDisplayRemoved");
            this.chkDisplayRemoved.Name = "chkDisplayRemoved";
            this.chkDisplayRemoved.UseVisualStyleBackColor = true;
            this.chkDisplayRemoved.CheckedChanged += new System.EventHandler(this.ChkDisplayRemoved_CheckedChanged);
            // 
            // FrmMatchTypes
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPlayerlist);
            this.Controls.Add(this.pnlPlayer);
            this.MaximizeBox = false;
            this.Name = "FrmMatchTypes";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.pnlPlayer.ResumeLayout(false);
            this.pnlPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOfMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeOnShootOutPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeEveryNumberOfServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScorePerSetToWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfSetsToWin)).EndInit();
            this.pnlPlayerlist.ResumeLayout(false);
            this.pnlPlayerlist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMatchTypes;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlPlayerlist;
        private System.Windows.Forms.Label lblRemoved;
        private System.Windows.Forms.CheckBox chkDisplayRemoved;
        private System.Windows.Forms.CheckBox chkRemoved;
        private System.Windows.Forms.Label lblMatchResults;
        private System.Windows.Forms.Label lblPlayedMatches;
        private System.Windows.Forms.NumericUpDown numServiceChangeOnShootOutPer;
        private System.Windows.Forms.CheckBox chkTwoPointsDifferenceToWin;
        private System.Windows.Forms.Label lblAvailableForTwoVsTwo;
        private System.Windows.Forms.CheckBox chkAvailableForTwoVsTwo;
        private System.Windows.Forms.Label lblServiceChangeOnShootOutPer;
        private System.Windows.Forms.Label lblTwoPointsDifferenceToWin;
        private System.Windows.Forms.NumericUpDown numServiceChangeEveryNumberOfServices;
        private System.Windows.Forms.Label lblServiceChangeEveryNumberOfServices;
        private System.Windows.Forms.NumericUpDown numScorePerSetToWin;
        private System.Windows.Forms.Label lblScorePerSetToWin;
        private System.Windows.Forms.NumericUpDown numNumberOfSetsToWin;
        private System.Windows.Forms.Label lblNumberOfSetsToWin;
        private System.Windows.Forms.NumericUpDown numTimeOfMatch;
        private System.Windows.Forms.Label lblTimeOfMatch;
        private System.Windows.Forms.CheckBox chkTimedMatch;
        private System.Windows.Forms.Label lblTimedMatch;
    }
}