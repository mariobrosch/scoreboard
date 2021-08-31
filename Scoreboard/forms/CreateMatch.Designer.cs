
namespace Scoreboard.forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMatch));
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
            resources.ApplyResources(this.lblPlayerLeft, "lblPlayerLeft");
            this.lblPlayerLeft.Name = "lblPlayerLeft";
            // 
            // cboPlayerLeft
            // 
            resources.ApplyResources(this.cboPlayerLeft, "cboPlayerLeft");
            this.cboPlayerLeft.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlayerLeft.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerLeft.FormattingEnabled = true;
            this.cboPlayerLeft.Name = "cboPlayerLeft";
            // 
            // lblPlayerRight
            // 
            resources.ApplyResources(this.lblPlayerRight, "lblPlayerRight");
            this.lblPlayerRight.Name = "lblPlayerRight";
            // 
            // cboPlayerRight
            // 
            resources.ApplyResources(this.cboPlayerRight, "cboPlayerRight");
            this.cboPlayerRight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPlayerRight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerRight.FormattingEnabled = true;
            this.cboPlayerRight.Name = "cboPlayerRight";
            // 
            // cboPlayerRight2
            // 
            resources.ApplyResources(this.cboPlayerRight2, "cboPlayerRight2");
            this.cboPlayerRight2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPlayerRight2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerRight2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerRight2.FormattingEnabled = true;
            this.cboPlayerRight2.Name = "cboPlayerRight2";
            // 
            // lblPlayerRight2
            // 
            resources.ApplyResources(this.lblPlayerRight2, "lblPlayerRight2");
            this.lblPlayerRight2.Name = "lblPlayerRight2";
            // 
            // cboPlayerLeft2
            // 
            resources.ApplyResources(this.cboPlayerLeft2, "cboPlayerLeft2");
            this.cboPlayerLeft2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlayerLeft2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlayerLeft2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerLeft2.FormattingEnabled = true;
            this.cboPlayerLeft2.Name = "cboPlayerLeft2";
            // 
            // lblPlayerLeft2
            // 
            resources.ApplyResources(this.lblPlayerLeft2, "lblPlayerLeft2");
            this.lblPlayerLeft2.Name = "lblPlayerLeft2";
            // 
            // chkTwoVsTwoGame
            // 
            resources.ApplyResources(this.chkTwoVsTwoGame, "chkTwoVsTwoGame");
            this.chkTwoVsTwoGame.Name = "chkTwoVsTwoGame";
            this.chkTwoVsTwoGame.UseVisualStyleBackColor = true;
            this.chkTwoVsTwoGame.CheckedChanged += new System.EventHandler(this.ChkTwoVsTwoGame_CheckedChanged);
            // 
            // lblTwoVsTwoPlayerGame
            // 
            resources.ApplyResources(this.lblTwoVsTwoPlayerGame, "lblTwoVsTwoPlayerGame");
            this.lblTwoVsTwoPlayerGame.Name = "lblTwoVsTwoPlayerGame";
            // 
            // cboMatchType
            // 
            resources.ApplyResources(this.cboMatchType, "cboMatchType");
            this.cboMatchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMatchType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatchType.FormattingEnabled = true;
            this.cboMatchType.Name = "cboMatchType";
            this.cboMatchType.SelectedIndexChanged += new System.EventHandler(this.CboMatchType_SelectedIndexChanged);
            // 
            // lblMatchType
            // 
            resources.ApplyResources(this.lblMatchType, "lblMatchType");
            this.lblMatchType.Name = "lblMatchType";
            // 
            // txtMatchTypeDescription
            // 
            resources.ApplyResources(this.txtMatchTypeDescription, "txtMatchTypeDescription");
            this.txtMatchTypeDescription.Name = "txtMatchTypeDescription";
            this.txtMatchTypeDescription.ReadOnly = true;
            // 
            // btnStartNewGame
            // 
            resources.ApplyResources(this.btnStartNewGame, "btnStartNewGame");
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.UseVisualStyleBackColor = true;
            this.btnStartNewGame.Click += new System.EventHandler(this.BtnStartNewGame_Click);
            // 
            // lblHelp
            // 
            resources.ApplyResources(this.lblHelp, "lblHelp");
            this.lblHelp.Name = "lblHelp";
            // 
            // CreateMatch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.Name = "CreateMatch";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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