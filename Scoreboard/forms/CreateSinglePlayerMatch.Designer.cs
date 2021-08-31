
namespace Scoreboard.forms
{
    partial class CreateSinglePlayerMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSinglePlayerMatch));
            this.cboPlayer = new System.Windows.Forms.ComboBox();
            this.lblSelectPlayer = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboPlayer
            // 
            resources.ApplyResources(this.cboPlayer, "cboPlayer");
            this.cboPlayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayer.FormattingEnabled = true;
            this.cboPlayer.Name = "cboPlayer";
            // 
            // lblSelectPlayer
            // 
            resources.ApplyResources(this.lblSelectPlayer, "lblSelectPlayer");
            this.lblSelectPlayer.Name = "lblSelectPlayer";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // CreateSinglePlayerMatch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblSelectPlayer);
            this.Controls.Add(this.cboPlayer);
            this.MaximizeBox = false;
            this.Name = "CreateSinglePlayerMatch";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPlayer;
        private System.Windows.Forms.Label lblSelectPlayer;
        private System.Windows.Forms.Button btnStart;
    }
}