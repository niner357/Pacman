namespace LevelCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.constructionKitListView = new System.Windows.Forms.ListView();
            this.constructKitLabel = new System.Windows.Forms.Label();
            this.mapLabel = new System.Windows.Forms.Label();
            this.topMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Size = new System.Drawing.Size(644, 24);
            this.topMenuStrip.TabIndex = 0;
            this.topMenuStrip.Text = "topMenuStrip";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "Level";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.Color.Black;
            this.mapPanel.Location = new System.Drawing.Point(9, 44);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(512, 512);
            this.mapPanel.TabIndex = 1;
            this.mapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseDown);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
            this.mapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseUp);
            // 
            // constructionKitListView
            // 
            this.constructionKitListView.Location = new System.Drawing.Point(527, 44);
            this.constructionKitListView.Name = "constructionKitListView";
            this.constructionKitListView.Size = new System.Drawing.Size(109, 512);
            this.constructionKitListView.TabIndex = 2;
            this.constructionKitListView.UseCompatibleStateImageBehavior = false;
            // 
            // constructKitLabel
            // 
            this.constructKitLabel.AutoSize = true;
            this.constructKitLabel.Location = new System.Drawing.Point(524, 28);
            this.constructKitLabel.Name = "constructKitLabel";
            this.constructKitLabel.Size = new System.Drawing.Size(81, 13);
            this.constructKitLabel.TabIndex = 3;
            this.constructKitLabel.Text = "Construction Kit";
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Location = new System.Drawing.Point(12, 28);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(28, 13);
            this.mapLabel.TabIndex = 4;
            this.mapLabel.Text = "Map";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 564);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.constructKitLabel);
            this.Controls.Add(this.constructionKitListView);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.topMenuStrip);
            this.MainMenuStrip = this.topMenuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 603);
            this.MinimumSize = new System.Drawing.Size(660, 603);
            this.Name = "MainForm";
            this.Text = "Level Creator";
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.ListView constructionKitListView;
        private System.Windows.Forms.Label constructKitLabel;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

