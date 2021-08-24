
namespace ttManager.forms
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
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlPlayerlist = new System.Windows.Forms.Panel();
            this.lblPossibleValues = new System.Windows.Forms.Label();
            this.lblForPossibleValuesLabel = new System.Windows.Forms.Label();
            this.pnlPlayer.SuspendLayout();
            this.pnlPlayerlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSettings
            // 
            this.lbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettings.FormattingEnabled = true;
            this.lbSettings.Location = new System.Drawing.Point(0, 0);
            this.lbSettings.Name = "lbSettings";
            this.lbSettings.Size = new System.Drawing.Size(151, 198);
            this.lbSettings.TabIndex = 0;
            this.lbSettings.SelectedIndexChanged += new System.EventHandler(this.LbSettings_SelectedIndexChanged);
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.Controls.Add(this.lblForPossibleValuesLabel);
            this.pnlPlayer.Controls.Add(this.lblPossibleValues);
            this.pnlPlayer.Controls.Add(this.lblValue);
            this.pnlPlayer.Controls.Add(this.txtValue);
            this.pnlPlayer.Controls.Add(this.lblKey);
            this.pnlPlayer.Controls.Add(this.Key);
            this.pnlPlayer.Controls.Add(this.txtId);
            this.pnlPlayer.Controls.Add(this.lblId);
            this.pnlPlayer.Controls.Add(this.btnSave);
            this.pnlPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayer.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new System.Drawing.Size(546, 198);
            this.pnlPlayer.TabIndex = 0;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(245, 89);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(295, 86);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(226, 20);
            this.txtValue.TabIndex = 2;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(254, 63);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 5;
            this.lblKey.Text = "Key";
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(295, 60);
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            this.Key.Size = new System.Drawing.Size(226, 20);
            this.Key.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(295, 34);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(226, 20);
            this.txtId.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(263, 37);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(446, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pnlPlayerlist
            // 
            this.pnlPlayerlist.Controls.Add(this.lbSettings);
            this.pnlPlayerlist.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPlayerlist.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayerlist.Name = "pnlPlayerlist";
            this.pnlPlayerlist.Size = new System.Drawing.Size(151, 198);
            this.pnlPlayerlist.TabIndex = 2;
            // 
            // lblPossibleValues
            // 
            this.lblPossibleValues.AutoSize = true;
            this.lblPossibleValues.Location = new System.Drawing.Point(292, 119);
            this.lblPossibleValues.Name = "lblPossibleValues";
            this.lblPossibleValues.Size = new System.Drawing.Size(10, 13);
            this.lblPossibleValues.TabIndex = 9;
            this.lblPossibleValues.Text = "-";
            // 
            // lblForPossibleValuesLabel
            // 
            this.lblForPossibleValuesLabel.AutoSize = true;
            this.lblForPossibleValuesLabel.Location = new System.Drawing.Point(172, 119);
            this.lblForPossibleValuesLabel.Name = "lblForPossibleValuesLabel";
            this.lblForPossibleValuesLabel.Size = new System.Drawing.Size(107, 13);
            this.lblForPossibleValuesLabel.TabIndex = 10;
            this.lblForPossibleValuesLabel.Text = "Toegestane waardes";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 198);
            this.Controls.Add(this.pnlPlayerlist);
            this.Controls.Add(this.pnlPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Instellingen";
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
    }
}