
namespace Scoreboard.forms
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.lbSettings = new System.Windows.Forms.ListBox();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblForPossibleValuesLabel = new System.Windows.Forms.Label();
            this.lblPossibleValues = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlPlayerlist = new System.Windows.Forms.Panel();
            this.pnlPlayer.SuspendLayout();
            this.pnlPlayerlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSettings
            // 
            resources.ApplyResources(this.lbSettings, "lbSettings");
            this.lbSettings.FormattingEnabled = true;
            this.lbSettings.Name = "lbSettings";
            this.lbSettings.SelectedIndexChanged += new System.EventHandler(this.LbSettings_SelectedIndexChanged);
            // 
            // pnlPlayer
            // 
            resources.ApplyResources(this.pnlPlayer, "pnlPlayer");
            this.pnlPlayer.Controls.Add(this.label1);
            this.pnlPlayer.Controls.Add(this.lblForPossibleValuesLabel);
            this.pnlPlayer.Controls.Add(this.lblPossibleValues);
            this.pnlPlayer.Controls.Add(this.lblValue);
            this.pnlPlayer.Controls.Add(this.txtValue);
            this.pnlPlayer.Controls.Add(this.lblKey);
            this.pnlPlayer.Controls.Add(this.Key);
            this.pnlPlayer.Controls.Add(this.txtId);
            this.pnlPlayer.Controls.Add(this.lblId);
            this.pnlPlayer.Controls.Add(this.btnSave);
            this.pnlPlayer.Name = "pnlPlayer";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblForPossibleValuesLabel
            // 
            resources.ApplyResources(this.lblForPossibleValuesLabel, "lblForPossibleValuesLabel");
            this.lblForPossibleValuesLabel.Name = "lblForPossibleValuesLabel";
            // 
            // lblPossibleValues
            // 
            resources.ApplyResources(this.lblPossibleValues, "lblPossibleValues");
            this.lblPossibleValues.Name = "lblPossibleValues";
            // 
            // lblValue
            // 
            resources.ApplyResources(this.lblValue, "lblValue");
            this.lblValue.Name = "lblValue";
            // 
            // txtValue
            // 
            resources.ApplyResources(this.txtValue, "txtValue");
            this.txtValue.Name = "txtValue";
            // 
            // lblKey
            // 
            resources.ApplyResources(this.lblKey, "lblKey");
            this.lblKey.Name = "lblKey";
            // 
            // Key
            // 
            resources.ApplyResources(this.Key, "Key");
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            // 
            // txtId
            // 
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            // 
            // lblId
            // 
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.Name = "lblId";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pnlPlayerlist
            // 
            resources.ApplyResources(this.pnlPlayerlist, "pnlPlayerlist");
            this.pnlPlayerlist.Controls.Add(this.lbSettings);
            this.pnlPlayerlist.Name = "pnlPlayerlist";
            // 
            // FrmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPlayerlist);
            this.Controls.Add(this.pnlPlayer);
            this.MaximizeBox = false;
            this.Name = "FrmSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.pnlPlayer.ResumeLayout(false);
            this.pnlPlayer.PerformLayout();
            this.pnlPlayerlist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSettings;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlPlayerlist;
        private System.Windows.Forms.Label lblForPossibleValuesLabel;
        private System.Windows.Forms.Label lblPossibleValues;
        private System.Windows.Forms.Label label1;
    }
}