
namespace ttManager.forms
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
            this.lbMatchTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMatchTypes.FormattingEnabled = true;
            this.lbMatchTypes.Location = new System.Drawing.Point(0, 0);
            this.lbMatchTypes.Name = "lbMatchTypes";
            this.lbMatchTypes.Size = new System.Drawing.Size(151, 450);
            this.lbMatchTypes.TabIndex = 0;
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
            this.pnlPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayer.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new System.Drawing.Size(800, 450);
            this.pnlPlayer.TabIndex = 1;
            // 
            // numServiceChangeOnShootOutPer
            // 
            this.numServiceChangeOnShootOutPer.Location = new System.Drawing.Point(314, 345);
            this.numServiceChangeOnShootOutPer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numServiceChangeOnShootOutPer.Name = "numServiceChangeOnShootOutPer";
            this.numServiceChangeOnShootOutPer.Size = new System.Drawing.Size(226, 20);
            this.numServiceChangeOnShootOutPer.TabIndex = 34;
            this.numServiceChangeOnShootOutPer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkTwoPointsDifferenceToWin
            // 
            this.chkTwoPointsDifferenceToWin.AutoSize = true;
            this.chkTwoPointsDifferenceToWin.Location = new System.Drawing.Point(314, 321);
            this.chkTwoPointsDifferenceToWin.Name = "chkTwoPointsDifferenceToWin";
            this.chkTwoPointsDifferenceToWin.Size = new System.Drawing.Size(15, 14);
            this.chkTwoPointsDifferenceToWin.TabIndex = 33;
            this.chkTwoPointsDifferenceToWin.UseVisualStyleBackColor = true;
            // 
            // lblAvailableForTwoVsTwo
            // 
            this.lblAvailableForTwoVsTwo.AutoSize = true;
            this.lblAvailableForTwoVsTwo.Location = new System.Drawing.Point(208, 372);
            this.lblAvailableForTwoVsTwo.Name = "lblAvailableForTwoVsTwo";
            this.lblAvailableForTwoVsTwo.Size = new System.Drawing.Size(99, 13);
            this.lblAvailableForTwoVsTwo.TabIndex = 32;
            this.lblAvailableForTwoVsTwo.Text = "Geschikt voor 2vs2";
            // 
            // chkAvailableForTwoVsTwo
            // 
            this.chkAvailableForTwoVsTwo.AutoSize = true;
            this.chkAvailableForTwoVsTwo.Location = new System.Drawing.Point(314, 372);
            this.chkAvailableForTwoVsTwo.Name = "chkAvailableForTwoVsTwo";
            this.chkAvailableForTwoVsTwo.Size = new System.Drawing.Size(15, 14);
            this.chkAvailableForTwoVsTwo.TabIndex = 31;
            this.chkAvailableForTwoVsTwo.UseVisualStyleBackColor = true;
            // 
            // lblServiceChangeOnShootOutPer
            // 
            this.lblServiceChangeOnShootOutPer.AutoSize = true;
            this.lblServiceChangeOnShootOutPer.Location = new System.Drawing.Point(165, 349);
            this.lblServiceChangeOnShootOutPer.Name = "lblServiceChangeOnShootOutPer";
            this.lblServiceChangeOnShootOutPer.Size = new System.Drawing.Size(142, 13);
            this.lblServiceChangeOnShootOutPer.TabIndex = 30;
            this.lblServiceChangeOnShootOutPer.Text = "Service wissel (shoot out) na";
            // 
            // lblTwoPointsDifferenceToWin
            // 
            this.lblTwoPointsDifferenceToWin.AutoSize = true;
            this.lblTwoPointsDifferenceToWin.Location = new System.Drawing.Point(199, 321);
            this.lblTwoPointsDifferenceToWin.Name = "lblTwoPointsDifferenceToWin";
            this.lblTwoPointsDifferenceToWin.Size = new System.Drawing.Size(109, 13);
            this.lblTwoPointsDifferenceToWin.TabIndex = 27;
            this.lblTwoPointsDifferenceToWin.Text = "Twee punten verschil";
            // 
            // numServiceChangeEveryNumberOfServices
            // 
            this.numServiceChangeEveryNumberOfServices.Location = new System.Drawing.Point(314, 293);
            this.numServiceChangeEveryNumberOfServices.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numServiceChangeEveryNumberOfServices.Name = "numServiceChangeEveryNumberOfServices";
            this.numServiceChangeEveryNumberOfServices.Size = new System.Drawing.Size(226, 20);
            this.numServiceChangeEveryNumberOfServices.TabIndex = 26;
            this.numServiceChangeEveryNumberOfServices.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblServiceChangeEveryNumberOfServices
            // 
            this.lblServiceChangeEveryNumberOfServices.AutoSize = true;
            this.lblServiceChangeEveryNumberOfServices.Location = new System.Drawing.Point(186, 295);
            this.lblServiceChangeEveryNumberOfServices.Name = "lblServiceChangeEveryNumberOfServices";
            this.lblServiceChangeEveryNumberOfServices.Size = new System.Drawing.Size(121, 13);
            this.lblServiceChangeEveryNumberOfServices.TabIndex = 25;
            this.lblServiceChangeEveryNumberOfServices.Text = "Service wissel na aantal";
            // 
            // numScorePerGameToWin
            // 
            this.numScorePerGameToWin.Location = new System.Drawing.Point(314, 267);
            this.numScorePerGameToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScorePerGameToWin.Name = "numScorePerGameToWin";
            this.numScorePerGameToWin.Size = new System.Drawing.Size(226, 20);
            this.numScorePerGameToWin.TabIndex = 24;
            this.numScorePerGameToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblScorePerGameToWin
            // 
            this.lblScorePerGameToWin.AutoSize = true;
            this.lblScorePerGameToWin.Location = new System.Drawing.Point(180, 269);
            this.lblScorePerGameToWin.Name = "lblScorePerGameToWin";
            this.lblScorePerGameToWin.Size = new System.Drawing.Size(127, 13);
            this.lblScorePerGameToWin.TabIndex = 23;
            this.lblScorePerGameToWin.Text = "Punten per set voor winst";
            // 
            // numNumberOfGamesToWin
            // 
            this.numNumberOfGamesToWin.Location = new System.Drawing.Point(314, 241);
            this.numNumberOfGamesToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfGamesToWin.Name = "numNumberOfGamesToWin";
            this.numNumberOfGamesToWin.Size = new System.Drawing.Size(226, 20);
            this.numNumberOfGamesToWin.TabIndex = 22;
            this.numNumberOfGamesToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumberOfGamesToWin
            // 
            this.lblNumberOfGamesToWin.AutoSize = true;
            this.lblNumberOfGamesToWin.Location = new System.Drawing.Point(199, 243);
            this.lblNumberOfGamesToWin.Name = "lblNumberOfGamesToWin";
            this.lblNumberOfGamesToWin.Size = new System.Drawing.Size(110, 13);
            this.lblNumberOfGamesToWin.TabIndex = 21;
            this.lblNumberOfGamesToWin.Text = "Aantal sets voor winst";
            // 
            // lblMatchResults
            // 
            this.lblMatchResults.AutoSize = true;
            this.lblMatchResults.Location = new System.Drawing.Point(317, 394);
            this.lblMatchResults.Name = "lblMatchResults";
            this.lblMatchResults.Size = new System.Drawing.Size(0, 13);
            this.lblMatchResults.TabIndex = 16;
            // 
            // lblPlayedMatches
            // 
            this.lblPlayedMatches.AutoSize = true;
            this.lblPlayedMatches.Location = new System.Drawing.Point(193, 393);
            this.lblPlayedMatches.Name = "lblPlayedMatches";
            this.lblPlayedMatches.Size = new System.Drawing.Size(114, 13);
            this.lblPlayedMatches.TabIndex = 15;
            this.lblPlayedMatches.Text = "Gespeelde wedstrijden";
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.Location = new System.Drawing.Point(241, 415);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(66, 13);
            this.lblRemoved.TabIndex = 12;
            this.lblRemoved.Text = "Is verwijderd";
            // 
            // chkRemoved
            // 
            this.chkRemoved.AutoSize = true;
            this.chkRemoved.Location = new System.Drawing.Point(314, 415);
            this.chkRemoved.Name = "chkRemoved";
            this.chkRemoved.Size = new System.Drawing.Size(15, 14);
            this.chkRemoved.TabIndex = 11;
            this.chkRemoved.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(240, 89);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Omschrijving";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(314, 86);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(226, 149);
            this.txtDescription.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(280, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(27, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Titel";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(314, 60);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(226, 20);
            this.txtType.TabIndex = 4;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(314, 34);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(226, 20);
            this.txtId.TabIndex = 3;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(291, 37);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(632, 415);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Verwijderen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNew.Location = new System.Drawing.Point(0, 427);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(151, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nieuw";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // pnlPlayerlist
            // 
            this.pnlPlayerlist.Controls.Add(this.chkDisplayRemoved);
            this.pnlPlayerlist.Controls.Add(this.btnNew);
            this.pnlPlayerlist.Controls.Add(this.lbMatchTypes);
            this.pnlPlayerlist.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPlayerlist.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayerlist.Name = "pnlPlayerlist";
            this.pnlPlayerlist.Size = new System.Drawing.Size(151, 450);
            this.pnlPlayerlist.TabIndex = 2;
            // 
            // chkDisplayRemoved
            // 
            this.chkDisplayRemoved.AutoSize = true;
            this.chkDisplayRemoved.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkDisplayRemoved.Location = new System.Drawing.Point(0, 410);
            this.chkDisplayRemoved.Name = "chkDisplayRemoved";
            this.chkDisplayRemoved.Size = new System.Drawing.Size(151, 17);
            this.chkDisplayRemoved.TabIndex = 3;
            this.chkDisplayRemoved.Text = "Toon verwijderde spelers";
            this.chkDisplayRemoved.UseVisualStyleBackColor = true;
            this.chkDisplayRemoved.CheckedChanged += new System.EventHandler(this.ChkDisplayRemoved_CheckedChanged);
            // 
            // FrmMatchTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPlayerlist);
            this.Controls.Add(this.pnlPlayer);
            this.Name = "FrmMatchTypes";
            this.Text = "Wedstrijd types";
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