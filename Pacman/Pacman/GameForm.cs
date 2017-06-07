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
            level = new Level(this, new LevelDecoder(@"G:\RunLengthEncoding\Das ist ein LvL.jan", 512, 512));
            controlManager = new ControlManager(level.RendererPanel);
            GameLabel label = new GameLabel(0, "Pac-Man", 50, Color.Gold);
            label.Location = new Point(10, 10);
            controlManager.OnControlClick += ControlManager_OnControlClick;
            controlManager.AddControl(label);
            controlManager.Initialize();
            audioPlayer = new AudioPlayer();
            audioPlayer.MusicPlayer.PlayNext();
            Show();
        }

        private void ControlManager_OnControlClick(GameControl source, MouseButtons btn)
        {
            controlManager.HideControl(source.Id);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioPlayer.StopAll();
            //parentForm.Close();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            controlManager.ShowControl(0);
        }
    }
}
