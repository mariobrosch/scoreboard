
namespace ttManager.forms
{
    partial class FrmPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlayers));
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.lblMatchResults = new System.Windows.Forms.Label();
            this.lblPlayedMatches = new System.Windows.Forms.Label();
            this.lblRemoved = new System.Windows.Forms.Label();
            this.chkRemoved = new System.Windows.Forms.CheckBox();
            this.lblEnabled = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlPlayerlist = new System.Windows.Forms.Panel();
            this.chkDisplayRemoved = new System.Windows.Forms.CheckBox();
            this.lblSinglePlayerMatches = new System.Windows.Forms.Label();
            this.lblOfTheLabelSinglePlayerMatches = new System.Windows.Forms.Label();
            this.pnlPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.pnlPlayerlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPlayers
            // 
            this.lbPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.ItemHeight = 25;
            this.lbPlayers.Location = new System.Drawing.Point(0, 0);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(151, 450);
            this.lbPlayers.TabIndex = 0;
            this.lbPlayers.SelectedIndexChanged += new System.EventHandler(this.LbPlayers_SelectedIndexChanged);
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.Controls.Add(this.lblSinglePlayerMatches);
            this.pnlPlayer.Controls.Add(this.lblOfTheLabelSinglePlayerMatches);
            this.pnlPlayer.Controls.Add(this.lblMatchResults);
            this.pnlPlayer.Controls.Add(this.lblPlayedMatches);
            this.pnlPlayer.Controls.Add(this.lblRemoved);
            this.pnlPlayer.Controls.Add(this.chkRemoved);
            this.pnlPlayer.Controls.Add(this.lblEnabled);
            this.pnlPlayer.Controls.Add(this.chkEnabled);
            this.pnlPlayer.Controls.Add(this.pbPhoto);
            this.pnlPlayer.Controls.Add(this.lblPhoto);
            this.pnlPlayer.Controls.Add(this.txtPhoto);
            this.pnlPlayer.Controls.Add(this.lblName);
            this.pnlPlayer.Controls.Add(this.txtName);
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
            // lblMatchResults
            // 
            this.lblMatchResults.AutoSize = true;
            this.lblMatchResults.Location = new System.Drawing.Point(292, 371);
            this.lblMatchResults.Name = "lblMatchResults";
            this.lblMatchResults.Size = new System.Drawing.Size(0, 13);
            this.lblMatchResults.TabIndex = 14;
            // 
            // lblPlayedMatches
            // 
            this.lblPlayedMatches.AutoSize = true;
            this.lblPlayedMatches.Location = new System.Drawing.Point(165, 371);
            this.lblPlayedMatches.Name = "lblPlayedMatches";
            this.lblPlayedMatches.Size = new System.Drawing.Size(114, 13);
            this.lblPlayedMatches.TabIndex = 13;
            this.lblPlayedMatches.Text = "Gespeelde wedstrijden";
            // 
            // lblRemoved
            // 
            this.lblRemoved.AutoSize = true;
            this.lblRemoved.Location = new System.Drawing.Point(213, 415);
            this.lblRemoved.Name = "lblRemoved";
            this.lblRemoved.Size = new System.Drawing.Size(66, 13);
            this.lblRemoved.TabIndex = 12;
            this.lblRemoved.Text = "Is verwijderd";
            // 
            // chkRemoved
            // 
            this.chkRemoved.AutoSize = true;
            this.chkRemoved.Location = new System.Drawing.Point(295, 415);
            this.chkRemoved.Name = "chkRemoved";
            this.chkRemoved.Size = new System.Drawing.Size(15, 14);
            this.chkRemoved.TabIndex = 11;
            this.chkRemoved.UseVisualStyleBackColor = true;
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoSize = true;
            this.lblEnabled.Location = new System.Drawing.Point(205, 393);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(74, 13);
            this.lblEnabled.TabIndex = 10;
            this.lblEnabled.Text = "Actieve speler";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(295, 393);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkEnabled.TabIndex = 9;
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(295, 112);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(316, 220);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 8;
            this.pbPhoto.TabStop = false;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(237, 89);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(42, 13);
            this.lblPhoto.TabIndex = 7;
            this.lblPhoto.Text = "Foto url";
            // 
            // txtPhoto
            // 
            this.txtPhoto.Location = new System.Drawing.Point(295, 86);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(226, 20);
            this.txtPhoto.TabIndex = 6;
            this.txtPhoto.TextChanged += new System.EventHandler(this.TxtPhoto_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(244, 63);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(295, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(226, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(295, 34);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(226, 20);
            this.txtId.TabIndex = 3;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(263, 37);
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
            this.pnlPlayerlist.Controls.Add(this.lbPlayers);
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
            // lblSinglePlayerMatches
            // 
            this.lblSinglePlayerMatches.AutoSize = true;
            this.lblSinglePlayerMatches.Location = new System.Drawing.Point(292, 349);
            this.lblSinglePlayerMatches.Name = "lblSinglePlayerMatches";
            this.lblSinglePlayerMatches.Size = new System.Drawing.Size(0, 13);
            this.lblSinglePlayerMatches.TabIndex = 16;
            // 
            // lblOfTheLabelSinglePlayerMatches
            // 
            this.lblOfTheLabelSinglePlayerMatches.AutoSize = true;
            this.lblOfTheLabelSinglePlayerMatches.Location = new System.Drawing.Point(187, 349);
            this.lblOfTheLabelSinglePlayerMatches.Name = "lblOfTheLabelSinglePlayerMatches";
            this.lblOfTheLabelSinglePlayerMatches.Size = new System.Drawing.Size(92, 13);
            this.lblOfTheLabelSinglePlayerMatches.TabIndex = 15;
            this.lblOfTheLabelSinglePlayerMatches.Text = "Single player stats";
            // 
            // FrmPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPlayerlist);
            this.Controls.Add(this.pnlPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPlayers";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Spelers";
            this.pnlPlayer.ResumeLayout(false);
            this.pnlPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.pnlPlayerlist.ResumeLayout(false);
            this.pnlPlayerlist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPlayers;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlPlayerlist;
        private System.Windows.Forms.Label lblEnabled;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblRemoved;
        private System.Windows.Forms.CheckBox chkRemoved;
        private System.Windows.Forms.CheckBox chkDisplayRemoved;
        private System.Windows.Forms.Label lblMatchResults;
        private System.Windows.Forms.Label lblPlayedMatches;
        private System.Windows.Forms.Label lblSinglePlayerMatches;
        private System.Windows.Forms.Label lblOfTheLabelSinglePlayerMatches;
    }
}