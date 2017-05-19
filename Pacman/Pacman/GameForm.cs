using Pacman.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class GameForm : Form
    {
        private Form parentForm;
        public GameForm(Form parent)
        {
            parentForm = parent;
            InitializeComponent();
            AudioPlayer player = new AudioPlayer();
            player.MusicPlayer.PlayNext();
        }
    }
}
