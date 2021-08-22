
namespace ttManager.forms
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
            this.pnlLeft.Controls.Add(this.lbUnfinishedMatches);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(281, 357);
            this.pnlLeft.TabIndex = 0;
            // 
            // lbUnfinishedMatches
            // 
            this.lbUnfinishedMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnfinishedMatches.FormattingEnabled = true;
            this.lbUnfinishedMatches.Location = new System.Drawing.Point(0, 0);
            this.lbUnfinishedMatches.Name = "lbUnfinishedMatches";
            this.lbUnfinishedMatches.Size = new System.Drawing.Size(281, 357);
            this.lbUnfinishedMatches.TabIndex = 0;
            this.lbUnfinishedMatches.SelectedIndexChanged += new System.EventHandler(this.LbUnfinishedMatches_SelectedIndexChanged);
            // 
            // pnlMain
            // 
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
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(281, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(519, 357);
            this.pnlMain.TabIndex = 1;
            // 
            // lblGames
            // 
            this.lblGames.AutoSize = true;
            this.lblGames.Location = new System.Drawing.Point(61, 137);
            this.lblGames.Name = "lblGames";
            this.lblGames.Size = new System.Drawing.Size(40, 13);
            this.lblGames.TabIndex = 10;
            this.lblGames.Text = "Games";
            // 
            // txtGames
            // 
            this.txtGames.Location = new System.Drawing.Point(118, 134);
            this.txtGames.Multiline = true;
            this.txtGames.Name = "txtGames";
            this.txtGames.ReadOnly = true;
            this.txtGames.Size = new System.Drawing.Size(219, 190);
            this.txtGames.TabIndex = 9;
            // 
            // lblMatchDate
            // 
            this.lblMatchDate.AutoSize = true;
            this.lblMatchDate.Location = new System.Drawing.Point(61, 85);
            this.lblMatchDate.Name = "lblMatchDate";
            this.lblMatchDate.Size = new System.Drawing.Size(38, 13);
            this.lblMatchDate.TabIndex = 8;
            this.lblMatchDate.Text = "Datum";
            // 
            // txtMatchDate
            // 
            this.txtMatchDate.Location = new System.Drawing.Point(118, 82);
            this.txtMatchDate.Name = "txtMatchDate";
            this.txtMatchDate.ReadOnly = true;
            this.txtMatchDate.Size = new System.Drawing.Size(219, 20);
            this.txtMatchDate.TabIndex = 7;
            // 
            // txtStandings
            // 
            this.txtStandings.Location = new System.Drawing.Point(118, 108);
            this.txtStandings.Name = "txtStandings";
            this.txtStandings.ReadOnly = true;
            this.txtStandings.Size = new System.Drawing.Size(219, 20);
            this.txtStandings.TabIndex = 6;
            // 
            // lblStandings
            // 
            this.lblStandings.AutoSize = true;
            this.lblStandings.Location = new System.Drawing.Point(66, 111);
            this.lblStandings.Name = "lblStandings";
            this.lblStandings.Size = new System.Drawing.Size(35, 13);
            this.lblStandings.TabIndex = 5;
            this.lblStandings.Text = "Stand";
            // 
            // txtTeamRight
            // 
            this.txtTeamRight.Location = new System.Drawing.Point(118, 56);
            this.txtTeamRight.Name = "txtTeamRight";
            this.txtTeamRight.ReadOnly = true;
            this.txtTeamRight.Size = new System.Drawing.Size(219, 20);
            this.txtTeamRight.TabIndex = 4;
            // 
            // txtTeamLeft
            // 
            this.txtTeamLeft.Location = new System.Drawing.Point(118, 30);
            this.txtTeamLeft.Name = "txtTeamLeft";
            this.txtTeamLeft.ReadOnly = true;
            this.txtTeamLeft.Size = new System.Drawing.Size(219, 20);
            this.txtTeamLeft.TabIndex = 3;
            // 
            // lblTeamRight
            // 
            this.lblTeamRight.AutoSize = true;
            this.lblTeamRight.Location = new System.Drawing.Point(35, 59);
            this.lblTeamRight.Name = "lblTeamRight";
            this.lblTeamRight.Size = new System.Drawing.Size(66, 13);
            this.lblTeamRight.TabIndex = 2;
            this.lblTeamRight.Text = "Team rechts";
            // 
            // lblTeamLeft
            // 
            this.lblTeamLeft.AutoSize = true;
            this.lblTeamLeft.Location = new System.Drawing.Point(43, 33);
            this.lblTeamLeft.Name = "lblTeamLeft";
            this.lblTeamLeft.Size = new System.Drawing.Size(58, 13);
            this.lblTeamLeft.TabIndex = 1;
            this.lblTeamLeft.Text = "Team links";
            // 
            // btnContinueMatch
            // 
            this.btnContinueMatch.Location = new System.Drawing.Point(403, 322);
            this.btnContinueMatch.Name = "btnContinueMatch";
            this.btnContinueMatch.Size = new System.Drawing.Size(104, 23);
            this.btnContinueMatch.TabIndex = 0;
            this.btnContinueMatch.Text = "Verder spelen";
            this.btnContinueMatch.UseVisualStyleBackColor = true;
            this.btnContinueMatch.Click += new System.EventHandler(this.BtnContinueMatch_Click);
            // 
            // ContinueMatchSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ContinueMatchSelection";
            this.Text = "Verder met een wedstrijd";
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