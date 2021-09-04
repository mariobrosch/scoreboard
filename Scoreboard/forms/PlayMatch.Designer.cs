
namespace Scoreboard.forms
{
    partial class PlayMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMatch));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.btnLeftScore = new System.Windows.Forms.Button();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.btnRightScore = new System.Windows.Forms.Button();
            this.txtWinner = new System.Windows.Forms.TextBox();
            this.btnStartNewSet = new System.Windows.Forms.Button();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblTimePlayed = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.txtLeft);
            this.splitContainer.Panel1.Controls.Add(this.btnLeftScore);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtRight);
            this.splitContainer.Panel2.Controls.Add(this.btnRightScore);
            // 
            // txtLeft
            // 
            resources.ApplyResources(this.txtLeft, "txtLeft");
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            // 
            // btnLeftScore
            // 
            resources.ApplyResources(this.btnLeftScore, "btnLeftScore");
            this.btnLeftScore.Name = "btnLeftScore";
            this.btnLeftScore.UseVisualStyleBackColor = true;
            this.btnLeftScore.Click += new System.EventHandler(this.BtnLeftScore_Click);
            // 
            // txtRight
            // 
            resources.ApplyResources(this.txtRight, "txtRight");
            this.txtRight.Name = "txtRight";
            this.txtRight.ReadOnly = true;
            // 
            // btnRightScore
            // 
            resources.ApplyResources(this.btnRightScore, "btnRightScore");
            this.btnRightScore.Name = "btnRightScore";
            this.btnRightScore.UseVisualStyleBackColor = true;
            this.btnRightScore.Click += new System.EventHandler(this.BtnRightScore_Click);
            // 
            // txtWinner
            // 
            resources.ApplyResources(this.txtWinner, "txtWinner");
            this.txtWinner.Name = "txtWinner";
            // 
            // btnStartNewSet
            // 
            resources.ApplyResources(this.btnStartNewSet, "btnStartNewSet");
            this.btnStartNewSet.Name = "btnStartNewSet";
            this.btnStartNewSet.UseVisualStyleBackColor = true;
            this.btnStartNewSet.Click += new System.EventHandler(this.BtnStartNewSet_Click);
            // 
            // pnlTime
            // 
            this.pnlTime.Controls.Add(this.lblTimePlayed);
            resources.ApplyResources(this.pnlTime, "pnlTime");
            this.pnlTime.Name = "pnlTime";
            // 
            // lblTimePlayed
            // 
            resources.ApplyResources(this.lblTimePlayed, "lblTimePlayed");
            this.lblTimePlayed.Name = "lblTimePlayed";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.splitContainer);
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Name = "pnlButtons";
            // 
            // PlayMatch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTime);
            this.Controls.Add(this.btnStartNewSet);
            this.Controls.Add(this.txtWinner);
            this.KeyPreview = true;
            this.Name = "PlayMatch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayMatch_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlayMatch_KeyUp);
            this.Resize += new System.EventHandler(this.PlayMatch_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlTime.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnLeftScore;
        private System.Windows.Forms.Button btnRightScore;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.TextBox txtWinner;
        private System.Windows.Forms.Button btnStartNewSet;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Label lblTimePlayed;
        private System.Windows.Forms.Panel pnlButtons;
    }
}