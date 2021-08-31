namespace Scoreboard.forms
{
    partial class ContinueMatchSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinueMatchSelection));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lbUnfinishedMatches = new System.Windows.Forms.ListBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblGames = new System.Windows.Forms.Label();
            this.txtGames = new System.Windows.Forms.TextBox();
            this.lblMatchDate = new System.Windows.Forms.Label();
            this.txtMatchDate = new System.Windows.Forms.TextBox();
            this.txtStandings = new System.Windows.Forms.TextBox();
            this.lblStandings = new System.Windows.Forms.Label();
            this.txtTeamRight = new System.Windows.Forms.TextBox();
            this.txtTeamLeft = new System.Windows.Forms.TextBox();
            this.lblTeamRight = new System.Windows.Forms.Label();
            this.lblTeamLeft = new System.Windows.Forms.Label();
            this.btnContinueMatch = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Controls.Add(this.lbUnfinishedMatches);
            this.pnlLeft.Name = "pnlLeft";
            // 
            // lbUnfinishedMatches
            // 
            resources.ApplyResources(this.lbUnfinishedMatches, "lbUnfinishedMatches");
            this.lbUnfinishedMatches.FormattingEnabled = true;
            this.lbUnfinishedMatches.Name = "lbUnfinishedMatches";
            this.lbUnfinishedMatches.SelectedIndexChanged += new System.EventHandler(this.LbUnfinishedMatches_SelectedIndexChanged);
            this.lbUnfinishedMatches.DoubleClick += new System.EventHandler(this.LbUnfinishedMatches_DoubleClick);
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Controls.Add(this.lblGames);
            this.pnlMain.Controls.Add(this.txtGames);
            this.pnlMain.Controls.Add(this.lblMatchDate);
            this.pnlMain.Controls.Add(this.txtMatchDate);
            this.pnlMain.Controls.Add(this.txtStandings);
            this.pnlMain.Controls.Add(this.lblStandings);
            this.pnlMain.Controls.Add(this.txtTeamRight);
            this.pnlMain.Controls.Add(this.txtTeamLeft);
            this.pnlMain.Controls.Add(this.lblTeamRight);
            this.pnlMain.Controls.Add(this.lblTeamLeft);
            this.pnlMain.Controls.Add(this.btnContinueMatch);
            this.pnlMain.Name = "pnlMain";
            // 
            // lblGames
            // 
            resources.ApplyResources(this.lblGames, "lblGames");
            this.lblGames.Name = "lblGames";
            // 
            // txtGames
            // 
            resources.ApplyResources(this.txtGames, "txtGames");
            this.txtGames.Name = "txtGames";
            this.txtGames.ReadOnly = true;
            // 
            // lblMatchDate
            // 
            resources.ApplyResources(this.lblMatchDate, "lblMatchDate");
            this.lblMatchDate.Name = "lblMatchDate";
            // 
            // txtMatchDate
            // 
            resources.ApplyResources(this.txtMatchDate, "txtMatchDate");
            this.txtMatchDate.Name = "txtMatchDate";
            this.txtMatchDate.ReadOnly = true;
            // 
            // txtStandings
            // 
            resources.ApplyResources(this.txtStandings, "txtStandings");
            this.txtStandings.Name = "txtStandings";
            this.txtStandings.ReadOnly = true;
            // 
            // lblStandings
            // 
            resources.ApplyResources(this.lblStandings, "lblStandings");
            this.lblStandings.Name = "lblStandings";
            // 
            // txtTeamRight
            // 
            resources.ApplyResources(this.txtTeamRight, "txtTeamRight");
            this.txtTeamRight.Name = "txtTeamRight";
            this.txtTeamRight.ReadOnly = true;
            // 
            // txtTeamLeft
            // 
            resources.ApplyResources(this.txtTeamLeft, "txtTeamLeft");
            this.txtTeamLeft.Name = "txtTeamLeft";
            this.txtTeamLeft.ReadOnly = true;
            // 
            // lblTeamRight
            // 
            resources.ApplyResources(this.lblTeamRight, "lblTeamRight");
            this.lblTeamRight.Name = "lblTeamRight";
            // 
            // lblTeamLeft
            // 
            resources.ApplyResources(this.lblTeamLeft, "lblTeamLeft");
            this.lblTeamLeft.Name = "lblTeamLeft";
            // 
            // btnContinueMatch
            // 
            resources.ApplyResources(this.btnContinueMatch, "btnContinueMatch");
            this.btnContinueMatch.Name = "btnContinueMatch";
            this.btnContinueMatch.UseVisualStyleBackColor = true;
            this.btnContinueMatch.Click += new System.EventHandler(this.BtnContinueMatch_Click);
            // 
            // ContinueMatchSelection
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.MaximizeBox = false;
            this.Name = "ContinueMatchSelection";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ListBox lbUnfinishedMatches;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnContinueMatch;
        private System.Windows.Forms.Label lblGames;
        private System.Windows.Forms.TextBox txtGames;
        private System.Windows.Forms.Label lblMatchDate;
        private System.Windows.Forms.TextBox txtMatchDate;
        private System.Windows.Forms.TextBox txtStandings;
        private System.Windows.Forms.Label lblStandings;
        private System.Windows.Forms.TextBox txtTeamRight;
        private System.Windows.Forms.TextBox txtTeamLeft;
        private System.Windows.Forms.Label lblTeamRight;
        private System.Windows.Forms.Label lblTeamLeft;
    }
}