
namespace Scoreboard.forms
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
            this.lblSinglePlayerMatches = new System.Windows.Forms.Label();
            this.lblOfTheLabelSinglePlayerMatches = new System.Windows.Forms.Label();
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
            this.pnlPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.pnlPlayerlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPlayers
            // 
            resources.ApplyResources(this.lbPlayers, "lbPlayers");
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.SelectedIndexChanged += new System.EventHandler(this.LbPlayers_SelectedIndexChanged);
            // 
            // pnlPlayer
            // 
            resources.ApplyResources(this.pnlPlayer, "pnlPlayer");
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
            this.pnlPlayer.Name = "pnlPlayer";
            // 
            // lblSinglePlayerMatches
            // 
            resources.ApplyResources(this.lblSinglePlayerMatches, "lblSinglePlayerMatches");
            this.lblSinglePlayerMatches.Name = "lblSinglePlayerMatches";
            // 
            // lblOfTheLabelSinglePlayerMatches
            // 
            resources.ApplyResources(this.lblOfTheLabelSinglePlayerMatches, "lblOfTheLabelSinglePlayerMatches");
            this.lblOfTheLabelSinglePlayerMatches.Name = "lblOfTheLabelSinglePlayerMatches";
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
            // lblEnabled
            // 
            resources.ApplyResources(this.lblEnabled, "lblEnabled");
            this.lblEnabled.Name = "lblEnabled";
            // 
            // chkEnabled
            // 
            resources.ApplyResources(this.chkEnabled, "chkEnabled");
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // pbPhoto
            // 
            resources.ApplyResources(this.pbPhoto, "pbPhoto");
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.TabStop = false;
            // 
            // lblPhoto
            // 
            resources.ApplyResources(this.lblPhoto, "lblPhoto");
            this.lblPhoto.Name = "lblPhoto";
            // 
            // txtPhoto
            // 
            resources.ApplyResources(this.txtPhoto, "txtPhoto");
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.TextChanged += new System.EventHandler(this.TxtPhoto_TextChanged);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
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
            resources.ApplyResources(this.pnlPlayerlist, "pnlPlayerlist");
            this.pnlPlayerlist.Controls.Add(this.chkDisplayRemoved);
            this.pnlPlayerlist.Controls.Add(this.btnNew);
            this.pnlPlayerlist.Controls.Add(this.lbPlayers);
            this.pnlPlayerlist.Name = "pnlPlayerlist";
            // 
            // chkDisplayRemoved
            // 
            resources.ApplyResources(this.chkDisplayRemoved, "chkDisplayRemoved");
            this.chkDisplayRemoved.Name = "chkDisplayRemoved";
            this.chkDisplayRemoved.UseVisualStyleBackColor = true;
            this.chkDisplayRemoved.CheckedChanged += new System.EventHandler(this.ChkDisplayRemoved_CheckedChanged);
            // 
            // FrmPlayers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPlayerlist);
            this.Controls.Add(this.pnlPlayer);
            this.MaximizeBox = false;
            this.Name = "FrmPlayers";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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