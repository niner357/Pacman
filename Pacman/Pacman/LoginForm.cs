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
using System.Security.Cryptography;

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
            if (string.IsNullOrEmpty(usernameTextBox.Text))
            {
                MessageBox.Show("The Username is empty! Please enter a Username!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("The Password is empty! Please enter a Password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(passwordTextBox.Text.Length < 6)
            {
                MessageBox.Show("The Password invalid! Please enter a Password (min. 6 Letters)!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = usernameTextBox.Text.ToLower();
            string password = EncryptMD5(passwordTextBox.Text);
            Database database = new Database();
            string dataset = database.Select("Verified", "Username='" + username + "' AND Password='" + password + "'");
            if(dataset != "")
            {
                if(dataset == "1")
                {
                    //START
                }
                else
                {
                    DialogResult result = MessageBox.Show("You are not verified yet! Please verify your Account first! Do you want to open the Verifysection?", "Error!", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            Process.Start("http://dasdarki.de/pacman/index_logged.php?mod=verification");
                            break;
                        case DialogResult.No:

                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("The Combination of Username and Password does not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Encrypts the String MD5
        /// </summary>
        /// <param name="text">The String which should encrypted</param>
        /// <returns>Encrypted MD5 String</returns>
        private string EncryptMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        private void usernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                passwordTextBox.Focus();
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                loginButton.Focus();
            }
        }

        private void loginButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                registerButton.Focus();
            }
        }

        private void registerButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                usernameTextBox.Focus();
            }
        }
    }
}
