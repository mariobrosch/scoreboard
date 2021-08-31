
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
            this.btnStartNewGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.Controls.Add(this.txtLeft);
            this.splitContainer.Panel1.Controls.Add(this.btnLeftScore);
            // 
            // splitContainer.Panel2
            // 
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
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
            // btnStartNewGame
            // 
            resources.ApplyResources(this.btnStartNewGame, "btnStartNewGame");
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.UseVisualStyleBackColor = true;
            this.btnStartNewGame.Click += new System.EventHandler(this.BtnStartNewGame_Click);
            // 
            // PlayMatch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartNewGame);
            this.Controls.Add(this.splitContainer);
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
        private System.Windows.Forms.Button btnStartNewGame;
    }
}