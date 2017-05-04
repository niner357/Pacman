using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] test1 = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            string[] test2 = test1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hallo
        }
    }
}
