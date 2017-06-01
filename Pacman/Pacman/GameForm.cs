using Pacman.Audio;
using Pacman.Controls;
using Pacman.Map;
using Pacman.Rendering;
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
        private AudioPlayer audioPlayer;
        private Form parentForm;
        private Level level;
        private ControlManager controlManager;

        public GameForm(Form parent)
        {
            parentForm = parent;
            //parent.Hide();
            InitializeComponent();
            level = new Level(this, new LevelDecoder("G:\\RunLengthEncoding\\Das ist ein LvL.jan", 512, 512));
            //controlManager = new ControlManager(this);
            GameLabel label = new GameLabel("Pac-Man", 50, Color.Gold);
            label.Location = new Point(10, 10);
            //controlManager.AddControl(label);
            //controlManager.Initialize(bufferBitmap, bufferGraphics, screenGraphics);
            audioPlayer = new AudioPlayer();
            audioPlayer.MusicPlayer.PlayNext();
            Show();
            //level.Player.Spawn(100, 100);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioPlayer.StopAll();
            //parentForm.Close();
        }
    }
}
