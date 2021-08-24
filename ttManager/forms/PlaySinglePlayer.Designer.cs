
namespace ttManager.forms
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
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(272, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 42);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblScoreInput
            // 
            this.lblScoreInput.AutoSize = true;
            this.lblScoreInput.Location = new System.Drawing.Point(78, 47);
            this.lblScoreInput.Name = "lblScoreInput";
            this.lblScoreInput.Size = new System.Drawing.Size(79, 13);
            this.lblScoreInput.TabIndex = 1;
            this.lblScoreInput.Text = "Score invoeren";
            // 
            // numScore
            // 
            this.numScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numScore.Location = new System.Drawing.Point(182, 36);
            this.numScore.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(120, 31);
            this.numScore.TabIndex = 0;
            // 
            // lblPreviousRecord
            // 
            this.lblPreviousRecord.AutoSize = true;
            this.lblPreviousRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousRecord.Location = new System.Drawing.Point(8, 74);
            this.lblPreviousRecord.Name = "lblPreviousRecord";
            this.lblPreviousRecord.Size = new System.Drawing.Size(0, 25);
            this.lblPreviousRecord.TabIndex = 3;
            // 
            // PlaySinglePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 165);
            this.Controls.Add(this.lblPreviousRecord);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.lblScoreInput);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlaySinglePlayer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Score invoer single player";
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