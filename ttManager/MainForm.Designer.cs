﻿
namespace ttManager
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
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnMatchTypes = new System.Windows.Forms.Button();
            this.btnNewMatch = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataExporterenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdZipfile = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlayers
            // 
            this.btnPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayers.Location = new System.Drawing.Point(12, 33);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(311, 229);
            this.btnPlayers.TabIndex = 1;
            this.btnPlayers.Text = "Spelers";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.BtnPlayers_Click);
            // 
            // btnMatchTypes
            // 
            this.btnMatchTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchTypes.Location = new System.Drawing.Point(12, 268);
            this.btnMatchTypes.Name = "btnMatchTypes";
            this.btnMatchTypes.Size = new System.Drawing.Size(311, 229);
            this.btnMatchTypes.TabIndex = 2;
            this.btnMatchTypes.Text = "Speltypes";
            this.btnMatchTypes.UseVisualStyleBackColor = true;
            this.btnMatchTypes.Click += new System.EventHandler(this.BtnMatchTypes_Click);
            // 
            // btnNewMatch
            // 
            this.btnNewMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMatch.Location = new System.Drawing.Point(329, 33);
            this.btnNewMatch.Name = "btnNewMatch";
            this.btnNewMatch.Size = new System.Drawing.Size(311, 229);
            this.btnNewMatch.TabIndex = 3;
            this.btnNewMatch.Text = "Nieuw spel";
            this.btnNewMatch.UseVisualStyleBackColor = true;
            this.btnNewMatch.Click += new System.EventHandler(this.BtnNewMatch_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(329, 268);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(311, 229);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Verder spelen";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataExporterenToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // dataExporterenToolStripMenuItem
            // 
            this.dataExporterenToolStripMenuItem.Name = "dataExporterenToolStripMenuItem";
            this.dataExporterenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataExporterenToolStripMenuItem.Text = "Data exporteren";
            this.dataExporterenToolStripMenuItem.Click += new System.EventHandler(this.DataExporterenToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 509);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnNewMatch);
            this.Controls.Add(this.btnMatchTypes);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Tabletennis Manager";
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
    }
}
