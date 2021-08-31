
namespace Scoreboard
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnMatchTypes = new System.Windows.Forms.Button();
            this.btnNewMatch = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataExporterenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spelersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speltypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spelenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verderSpelenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nieuwSpelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdZipfile = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlayers
            // 
            resources.ApplyResources(this.btnPlayers, "btnPlayers");
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.BtnPlayers_Click);
            // 
            // btnMatchTypes
            // 
            resources.ApplyResources(this.btnMatchTypes, "btnMatchTypes");
            this.btnMatchTypes.Name = "btnMatchTypes";
            this.btnMatchTypes.UseVisualStyleBackColor = true;
            this.btnMatchTypes.Click += new System.EventHandler(this.BtnMatchTypes_Click);
            // 
            // btnNewMatch
            // 
            resources.ApplyResources(this.btnNewMatch, "btnNewMatch");
            this.btnNewMatch.Name = "btnNewMatch";
            this.btnNewMatch.UseVisualStyleBackColor = true;
            this.btnNewMatch.Click += new System.EventHandler(this.BtnNewMatch_Click);
            // 
            // btnContinue
            // 
            resources.ApplyResources(this.btnContinue, "btnContinue");
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.spelersToolStripMenuItem,
            this.speltypesToolStripMenuItem,
            this.spelenToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataExporterenToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            // 
            // dataExporterenToolStripMenuItem
            // 
            resources.ApplyResources(this.dataExporterenToolStripMenuItem, "dataExporterenToolStripMenuItem");
            this.dataExporterenToolStripMenuItem.Name = "dataExporterenToolStripMenuItem";
            this.dataExporterenToolStripMenuItem.Click += new System.EventHandler(this.DataExporterenToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // spelersToolStripMenuItem
            // 
            resources.ApplyResources(this.spelersToolStripMenuItem, "spelersToolStripMenuItem");
            this.spelersToolStripMenuItem.Name = "spelersToolStripMenuItem";
            this.spelersToolStripMenuItem.Click += new System.EventHandler(this.SpelersToolStripMenuItem_Click);
            // 
            // speltypesToolStripMenuItem
            // 
            resources.ApplyResources(this.speltypesToolStripMenuItem, "speltypesToolStripMenuItem");
            this.speltypesToolStripMenuItem.Name = "speltypesToolStripMenuItem";
            this.speltypesToolStripMenuItem.Click += new System.EventHandler(this.SpeltypesToolStripMenuItem_Click);
            // 
            // spelenToolStripMenuItem
            // 
            resources.ApplyResources(this.spelenToolStripMenuItem, "spelenToolStripMenuItem");
            this.spelenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verderSpelenToolStripMenuItem,
            this.singlePlayerToolStripMenuItem,
            this.nieuwSpelToolStripMenuItem});
            this.spelenToolStripMenuItem.Name = "spelenToolStripMenuItem";
            // 
            // verderSpelenToolStripMenuItem
            // 
            resources.ApplyResources(this.verderSpelenToolStripMenuItem, "verderSpelenToolStripMenuItem");
            this.verderSpelenToolStripMenuItem.Name = "verderSpelenToolStripMenuItem";
            this.verderSpelenToolStripMenuItem.Click += new System.EventHandler(this.VerderSpelenToolStripMenuItem_Click);
            // 
            // singlePlayerToolStripMenuItem
            // 
            resources.ApplyResources(this.singlePlayerToolStripMenuItem, "singlePlayerToolStripMenuItem");
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.SinglePlayerToolStripMenuItem_Click);
            // 
            // nieuwSpelToolStripMenuItem
            // 
            resources.ApplyResources(this.nieuwSpelToolStripMenuItem, "nieuwSpelToolStripMenuItem");
            this.nieuwSpelToolStripMenuItem.Name = "nieuwSpelToolStripMenuItem";
            this.nieuwSpelToolStripMenuItem.Click += new System.EventHandler(this.NieuwSpelToolStripMenuItem_Click);
            // 
            // sfdZipfile
            // 
            resources.ApplyResources(this.sfdZipfile, "sfdZipfile");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnNewMatch);
            this.Controls.Add(this.btnMatchTypes);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnMatchTypes;
        private System.Windows.Forms.Button btnNewMatch;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataExporterenToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdZipfile;
        private System.Windows.Forms.ToolStripMenuItem spelersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speltypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spelenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verderSpelenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nieuwSpelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

