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
        private Graphics bufferGraphics;
        private Graphics screenGraphics;
        private Bitmap bufferBitmap;

        public GameForm(Form parent)
        {
            parentForm = parent;
            parent.Hide();
            InitializeComponent();
            bufferBitmap = new Bitmap(fieldPanel.Width, fieldPanel.Height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = fieldPanel.CreateGraphics();
            level = new Level(this, fieldPanel, new LevelDecoder("", fieldPanel.Width, fieldPanel.Height));
            controlManager = new ControlManager(fieldPanel);
            GameLabel label = new GameLabel("Pac-Man", 50, Color.Gold);
            label.Location = new Point(10, 10);
            controlManager.AddControl(label);
            controlManager.Initialize(bufferBitmap, bufferGraphics, screenGraphics);
            audioPlayer = new AudioPlayer();
            audioPlayer.MusicPlayer.PlayNext();
            Show();
            level.Player.Spawn(100, 100);
        }
        public GameForm()
        {

        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioPlayer.StopAll();
            parentForm.Close();
        }
    }
}
