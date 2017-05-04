namespace ResourcePacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.resourcesListBox = new System.Windows.Forms.ListBox();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(56, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(81, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name:";
            // 
            // goButton
            // 
            this.goButton.BackgroundImage = global::ResourcePacker.Properties.Resources.Ok_icon;
            this.goButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.goButton.Location = new System.Drawing.Point(184, 186);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(50, 50);
            this.goButton.TabIndex = 6;
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackgroundImage = global::ResourcePacker.Properties.Resources.edit_remove;
            this.removeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeButton.Location = new System.Drawing.Point(71, 186);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(50, 50);
            this.removeButton.TabIndex = 5;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::ResourcePacker.Properties.Resources.add_icon;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.Location = new System.Drawing.Point(15, 186);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(50, 50);
            this.addButton.TabIndex = 4;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // resourcesListBox
            // 
            this.resourcesListBox.FormattingEnabled = true;
            this.resourcesListBox.Location = new System.Drawing.Point(15, 32);
            this.resourcesListBox.Name = "resourcesListBox";
            this.resourcesListBox.Size = new System.Drawing.Size(219, 147);
            this.resourcesListBox.TabIndex = 7;
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(207, 182);
            this.outputRichTextBox.TabIndex = 8;
            this.outputRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outputRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 207);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 241);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resourcesListBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(262, 280);
            this.MinimumSize = new System.Drawing.Size(262, 280);
            this.Name = "MainForm";
            this.Text = "ResourcePacker";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ListBox resourcesListBox;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}

