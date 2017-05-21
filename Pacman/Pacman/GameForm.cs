using Pacman.Audio;
using Pacman.Controls;
using Pacman.Map;
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
            parent.Hide();
            InitializeComponent();
            level = new Level(fieldPanel, new LevelDecoder("", fieldPanel.Width, fieldPanel.Height));
            controlManager = new ControlManager(fieldPanel);
            controlManager.AddControl(new GameLabel("Pac-Man", fieldPanel.Width, Color.Gold));
            audioPlayer = new AudioPlayer();
            audioPlayer.MusicPlayer.PlayNext();
            Show();
            level.Player.Spawn(100, 100);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Close();
        }
    }
}
