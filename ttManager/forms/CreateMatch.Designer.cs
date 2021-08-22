﻿
namespace ttManager.forms
{
    partial class CreateMatch
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
            this.lblPlayerLeft = new System.Windows.Forms.Label();
            this.cboPlayerLeft = new System.Windows.Forms.ComboBox();
            this.lblPlayerRight = new System.Windows.Forms.Label();
            this.cboPlayerRight = new System.Windows.Forms.ComboBox();
            this.cboPlayerRight2 = new System.Windows.Forms.ComboBox();
            this.lblPlayerRight2 = new System.Windows.Forms.Label();
            this.cboPlayerLeft2 = new System.Windows.Forms.ComboBox();
            this.lblPlayerLeft2 = new System.Windows.Forms.Label();
            this.chkTwoVsTwoGame = new System.Windows.Forms.CheckBox();
            this.lblTwoVsTwoPlayerGame = new System.Windows.Forms.Label();
            this.cboMatchType = new System.Windows.Forms.ComboBox();
            this.lblMatchType = new System.Windows.Forms.Label();
            this.txtMatchTypeDescription = new System.Windows.Forms.TextBox();
            this.btnStartNewGame = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerLeft
            // 
            this.lblPlayerLeft.AutoSize = true;
            this.lblPlayerLeft.Location = new System.Drawing.Point(18, 15);
            this.lblPlayerLeft.Name = "lblPlayerLeft";
            this.lblPlayerLeft.Size = new System.Drawing.Size(46, 13);
            this.lblPlayerLeft.TabIndex = 0;
            this.lblPlayerLeft.Text = "Speler 1";
            // 
            // cboPlayerLeft
            // 
            this.cboPlayerLeft.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlayerLeft.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerLeft.FormattingEnabled = true;
            this.cboPlayerLeft.Location = new System.Drawing.Point(69, 12);
            this.cboPlayerLeft.Name = "cboPlayerLeft";
            this.cboPlayerLeft.Size = new System.Drawing.Size(160, 21);
            this.cboPlayerLeft.TabIndex = 1;
            // 
            // lblPlayerRight
            // 
            this.lblPlayerRight.AutoSize = true;
            this.lblPlayerRight.Location = new System.Drawing.Point(382, 15);
            this.lblPlayerRight.Name = "lblPlayerRight";
            this.lblPlayerRight.Size = new System.Drawing.Size(46, 13);
            this.lblPlayerRight.TabIndex = 2;
            this.lblPlayerRight.Text = "Speler 1";
            // 
            // cboPlayerRight
            // 
            this.cboPlayerRight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPlayerRight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerRight.FormattingEnabled = true;
            this.cboPlayerRight.Location = new System.Drawing.Point(434, 12);
            this.cboPlayerRight.Name = "cboPlayerRight";
            this.cboPlayerRight.Size = new System.Drawing.Size(160, 21);
            this.cboPlayerRight.TabIndex = 3;
            // 
            // cboPlayerRight2
            // 
            this.cboPlayerRight2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPlayerRight2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerRight2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerRight2.FormattingEnabled = true;
            this.cboPlayerRight2.Location = new System.Drawing.Point(434, 59);
            this.cboPlayerRight2.Name = "cboPlayerRight2";
            this.cboPlayerRight2.Size = new System.Drawing.Size(160, 21);
            this.cboPlayerRight2.TabIndex = 5;
            this.cboPlayerRight2.Visible = false;
            // 
            // lblPlayerRight2
            // 
            this.lblPlayerRight2.AutoSize = true;
            this.lblPlayerRight2.Location = new System.Drawing.Point(382, 62);
            this.lblPlayerRight2.Name = "lblPlayerRight2";
            this.lblPlayerRight2.Size = new System.Drawing.Size(46, 13);
            this.lblPlayerRight2.TabIndex = 4;
            this.lblPlayerRight2.Text = "Speler 2";
            this.lblPlayerRight2.Visible = false;
            // 
            // cboPlayerLeft2
            // 
            this.cboPlayerLeft2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlayerLeft2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerLeft2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerLeft2.FormattingEnabled = true;
            this.cboPlayerLeft2.Location = new System.Drawing.Point(69, 59);
            this.cboPlayerLeft2.Name = "cboPlayerLeft2";
            this.cboPlayerLeft2.Size = new System.Drawing.Size(160, 21);
            this.cboPlayerLeft2.TabIndex = 7;
            this.cboPlayerLeft2.Visible = false;
            // 
            // lblPlayerLeft2
            // 
            this.lblPlayerLeft2.AutoSize = true;
            this.lblPlayerLeft2.Location = new System.Drawing.Point(17, 62);
            this.lblPlayerLeft2.Name = "lblPlayerLeft2";
            this.lblPlayerLeft2.Size = new System.Drawing.Size(46, 13);
            this.lblPlayerLeft2.TabIndex = 6;
            this.lblPlayerLeft2.Text = "Speler 2";
            this.lblPlayerLeft2.Visible = false;
            // 
            // chkTwoVsTwoGame
            // 
            this.chkTwoVsTwoGame.AutoSize = true;
            this.chkTwoVsTwoGame.Location = new System.Drawing.Point(69, 39);
            this.chkTwoVsTwoGame.Name = "chkTwoVsTwoGame";
            this.chkTwoVsTwoGame.Size = new System.Drawing.Size(15, 14);
            this.chkTwoVsTwoGame.TabIndex = 9;
            this.chkTwoVsTwoGame.UseVisualStyleBackColor = true;
            this.chkTwoVsTwoGame.CheckedChanged += new System.EventHandler(this.ChkTwoVsTwoGame_CheckedChanged);
            // 
            // lblTwoVsTwoPlayerGame
            // 
            this.lblTwoVsTwoPlayerGame.AutoSize = true;
            this.lblTwoVsTwoPlayerGame.Location = new System.Drawing.Point(27, 39);
            this.lblTwoVsTwoPlayerGame.Name = "lblTwoVsTwoPlayerGame";
            this.lblTwoVsTwoPlayerGame.Size = new System.Drawing.Size(36, 13);
            this.lblTwoVsTwoPlayerGame.TabIndex = 10;
            this.lblTwoVsTwoPlayerGame.Text = "2 vs 2";
            // 
            // cboMatchType
            // 
            this.cboMatchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMatchType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatchType.FormattingEnabled = true;
            this.cboMatchType.Location = new System.Drawing.Point(69, 116);
            this.cboMatchType.Name = "cboMatchType";
            this.cboMatchType.Size = new System.Drawing.Size(160, 21);
            this.cboMatchType.TabIndex = 11;
            this.cboMatchType.SelectedIndexChanged += new System.EventHandler(this.CboMatchType_SelectedIndexChanged);
            // 
            // lblMatchType
            // 
            this.lblMatchType.AutoSize = true;
            this.lblMatchType.Location = new System.Drawing.Point(18, 119);
            this.lblMatchType.Name = "lblMatchType";
            this.lblMatchType.Size = new System.Drawing.Size(48, 13);
            this.lblMatchType.TabIndex = 12;
            this.lblMatchType.Text = "Speltype";
            // 
            // txtMatchTypeDescription
            // 
            this.txtMatchTypeDescription.Location = new System.Drawing.Point(251, 116);
            this.txtMatchTypeDescription.Multiline = true;
            this.txtMatchTypeDescription.Name = "txtMatchTypeDescription";
            this.txtMatchTypeDescription.ReadOnly = true;
            this.txtMatchTypeDescription.Size = new System.Drawing.Size(343, 149);
            this.txtMatchTypeDescription.TabIndex = 13;
            // 
            // btnStartNewGame
            // 
            this.btnStartNewGame.Location = new System.Drawing.Point(519, 287);
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartNewGame.TabIndex = 14;
            this.btnStartNewGame.Text = "Start";
            this.btnStartNewGame.UseVisualStyleBackColor = true;
            this.btnStartNewGame.Click += new System.EventHandler(this.BtnStartNewGame_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(249, 292);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(179, 13);
            this.lblHelp.TabIndex = 15;
            this.lblHelp.Text = "Startspeler wordt willekeurig bepaald";
            // 
            // CreateMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 324);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnStartNewGame);
            this.Controls.Add(this.txtMatchTypeDescription);
            this.Controls.Add(this.lblMatchType);
            this.Controls.Add(this.cboMatchType);
            this.Controls.Add(this.lblTwoVsTwoPlayerGame);
            this.Controls.Add(this.chkTwoVsTwoGame);
            this.Controls.Add(this.cboPlayerLeft2);
            this.Controls.Add(this.lblPlayerLeft2);
            this.Controls.Add(this.cboPlayerRight2);
            this.Controls.Add(this.lblPlayerRight2);
            this.Controls.Add(this.cboPlayerRight);
            this.Controls.Add(this.lblPlayerRight);
            this.Controls.Add(this.cboPlayerLeft);
            this.Controls.Add(this.lblPlayerLeft);
            this.Name = "CreateMatch";
            this.Text = "Spel aanmaken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerLeft;
        private System.Windows.Forms.ComboBox cboPlayerLeft;
        private System.Windows.Forms.Label lblPlayerRight;
        private System.Windows.Forms.ComboBox cboPlayerRight;
        private System.Windows.Forms.ComboBox cboPlayerRight2;
        private System.Windows.Forms.Label lblPlayerRight2;
        private System.Windows.Forms.ComboBox cboPlayerLeft2;
        private System.Windows.Forms.Label lblPlayerLeft2;
        private System.Windows.Forms.CheckBox chkTwoVsTwoGame;
        private System.Windows.Forms.Label lblTwoVsTwoPlayerGame;
        private System.Windows.Forms.ComboBox cboMatchType;
        private System.Windows.Forms.Label lblMatchType;
        private System.Windows.Forms.TextBox txtMatchTypeDescription;
        private System.Windows.Forms.Button btnStartNewGame;
        private System.Windows.Forms.Label lblHelp;
    }
}