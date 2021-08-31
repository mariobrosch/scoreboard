
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
            this.numServiceChangeOnShootOutPer = new System.Windows.Forms.NumericUpDown();
            this.chkTwoPointsDifferenceToWin = new System.Windows.Forms.CheckBox();
            this.lblAvailableForTwoVsTwo = new System.Windows.Forms.Label();
            this.chkAvailableForTwoVsTwo = new System.Windows.Forms.CheckBox();
            this.lblServiceChangeOnShootOutPer = new System.Windows.Forms.Label();
            this.lblTwoPointsDifferenceToWin = new System.Windows.Forms.Label();
            this.numServiceChangeEveryNumberOfServices = new System.Windows.Forms.NumericUpDown();
            this.lblServiceChangeEveryNumberOfServices = new System.Windows.Forms.Label();
            this.numScorePerGameToWin = new System.Windows.Forms.NumericUpDown();
            this.lblScorePerGameToWin = new System.Windows.Forms.Label();
            this.numNumberOfGamesToWin = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfGamesToWin = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeOnShootOutPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeEveryNumberOfServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScorePerGameToWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfGamesToWin)).BeginInit();
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
            this.pnlPlayer.Controls.Add(this.numServiceChangeOnShootOutPer);
            this.pnlPlayer.Controls.Add(this.chkTwoPointsDifferenceToWin);
            this.pnlPlayer.Controls.Add(this.lblAvailableForTwoVsTwo);
            this.pnlPlayer.Controls.Add(this.chkAvailableForTwoVsTwo);
            this.pnlPlayer.Controls.Add(this.lblServiceChangeOnShootOutPer);
            this.pnlPlayer.Controls.Add(this.lblTwoPointsDifferenceToWin);
            this.pnlPlayer.Controls.Add(this.numServiceChangeEveryNumberOfServices);
            this.pnlPlayer.Controls.Add(this.lblServiceChangeEveryNumberOfServices);
            this.pnlPlayer.Controls.Add(this.numScorePerGameToWin);
            this.pnlPlayer.Controls.Add(this.lblScorePerGameToWin);
            this.pnlPlayer.Controls.Add(this.numNumberOfGamesToWin);
            this.pnlPlayer.Controls.Add(this.lblNumberOfGamesToWin);
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
            // numScorePerGameToWin
            // 
            resources.ApplyResources(this.numScorePerGameToWin, "numScorePerGameToWin");
            this.numScorePerGameToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScorePerGameToWin.Name = "numScorePerGameToWin";
            this.numScorePerGameToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblScorePerGameToWin
            // 
            resources.ApplyResources(this.lblScorePerGameToWin, "lblScorePerGameToWin");
            this.lblScorePerGameToWin.Name = "lblScorePerGameToWin";
            // 
            // numNumberOfGamesToWin
            // 
            resources.ApplyResources(this.numNumberOfGamesToWin, "numNumberOfGamesToWin");
            this.numNumberOfGamesToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfGamesToWin.Name = "numNumberOfGamesToWin";
            this.numNumberOfGamesToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberOfGamesToWin
            // 
            resources.ApplyResources(this.lblNumberOfGamesToWin, "lblNumberOfGamesToWin");
            this.lblNumberOfGamesToWin.Name = "lblNumberOfGamesToWin";
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
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeOnShootOutPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceChangeEveryNumberOfServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScorePerGameToWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfGamesToWin)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numScorePerGameToWin;
        private System.Windows.Forms.Label lblScorePerGameToWin;
        private System.Windows.Forms.NumericUpDown numNumberOfGamesToWin;
        private System.Windows.Forms.Label lblNumberOfGamesToWin;
    }
}