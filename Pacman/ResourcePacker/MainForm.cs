using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResourcesIO;

namespace ResourcePacker
{
    public partial class MainForm : Form
    {
        private Size normalSize;
        public MainForm()
        {
            InitializeComponent();
            normalSize = this.Size;
            MaximumSize = normalSize;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("The Name doesn't have to be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Options.Extension = ".alex";
                Options.NameAdditional = "resource_";
                List<string> list = new List<string>();
                foreach (Object item in resourcesListBox.Items)
                    list.Add((string)item);
                ResourceWriter writer = new ResourceWriter(nameTextBox.Text, list, dialog.SelectedPath, outputRichTextBox);
                writer.Write();
                MessageBox.Show("Done! Resource saved to " + writer.OutputPath, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (resourcesListBox.SelectedItem != null)
                resourcesListBox.Items.Remove(resourcesListBox.SelectedItem);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                resourcesListBox.Items.Add(dialog.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                ResourceReader reader = new ResourceReader(dialog.FileName);
                reader.Read();
            }
        }
    }
}
