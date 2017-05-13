using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using Pacman.MySQL;

namespace Pacman
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://dasdarki.de/pacman/register.php");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
