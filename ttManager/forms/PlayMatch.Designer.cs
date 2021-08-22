
namespace ttManager.forms
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
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer.Size = new System.Drawing.Size(800, 334);
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // txtLeft
            // 
            this.txtLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeft.Location = new System.Drawing.Point(0, 0);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            this.txtLeft.Size = new System.Drawing.Size(400, 80);
            this.txtLeft.TabIndex = 1;
            // 
            // btnLeftScore
            // 
            this.btnLeftScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftScore.Location = new System.Drawing.Point(0, 0);
            this.btnLeftScore.Name = "btnLeftScore";
            this.btnLeftScore.Size = new System.Drawing.Size(400, 334);
            this.btnLeftScore.TabIndex = 0;
            this.btnLeftScore.Text = "Links";
            this.btnLeftScore.UseVisualStyleBackColor = true;
            this.btnLeftScore.Click += new System.EventHandler(this.BtnLeftScore_Click);
            // 
            // txtRight
            // 
            this.txtRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRight.Location = new System.Drawing.Point(0, 0);
            this.txtRight.Name = "txtRight";
            this.txtRight.ReadOnly = true;
            this.txtRight.Size = new System.Drawing.Size(399, 80);
            this.txtRight.TabIndex = 2;
            // 
            // btnRightScore
            // 
            this.btnRightScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightScore.Location = new System.Drawing.Point(0, 0);
            this.btnRightScore.Name = "btnRightScore";
            this.btnRightScore.Size = new System.Drawing.Size(399, 334);
            this.btnRightScore.TabIndex = 1;
            this.btnRightScore.Text = "Rechts";
            this.btnRightScore.UseVisualStyleBackColor = true;
            this.btnRightScore.Click += new System.EventHandler(this.BtnRightScore_Click);
            // 
            // txtWinner
            // 
            this.txtWinner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWinner.Location = new System.Drawing.Point(0, 334);
            this.txtWinner.Name = "txtWinner";
            this.txtWinner.Size = new System.Drawing.Size(800, 116);
            this.txtWinner.TabIndex = 2;
            this.txtWinner.Visible = false;
            // 
            // btnStartNewGame
            // 
            this.btnStartNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartNewGame.Location = new System.Drawing.Point(220, 375);
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.Size = new System.Drawing.Size(362, 63);
            this.btnStartNewGame.TabIndex = 3;
            this.btnStartNewGame.Text = "Start nieuwe set";
            this.btnStartNewGame.UseVisualStyleBackColor = true;
            this.btnStartNewGame.Visible = false;
            this.btnStartNewGame.Click += new System.EventHandler(this.BtnStartNewGame_Click);
            // 
            // PlayMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStartNewGame);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.txtWinner);
            this.Name = "PlayMatch";
            this.Text = "PlayMatch";
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