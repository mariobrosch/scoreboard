
namespace Scoreboard.forms
{
    partial class PlaySinglePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaySinglePlayer));
            this.btnSave = new System.Windows.Forms.Button();
            this.lblScoreInput = new System.Windows.Forms.Label();
            this.numScore = new System.Windows.Forms.NumericUpDown();
            this.lblPreviousRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblScoreInput
            // 
            resources.ApplyResources(this.lblScoreInput, "lblScoreInput");
            this.lblScoreInput.Name = "lblScoreInput";
            // 
            // numScore
            // 
            resources.ApplyResources(this.numScore, "numScore");
            this.numScore.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numScore.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numScore.Name = "numScore";
            // 
            // lblPreviousRecord
            // 
            resources.ApplyResources(this.lblPreviousRecord, "lblPreviousRecord");
            this.lblPreviousRecord.Name = "lblPreviousRecord";
            // 
            // PlaySinglePlayer
            // 
            this.AcceptButton = this.btnSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPreviousRecord);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.lblScoreInput);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PlaySinglePlayer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlaySinglePlayer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblScoreInput;
        private System.Windows.Forms.NumericUpDown numScore;
        private System.Windows.Forms.Label lblPreviousRecord;
    }
}