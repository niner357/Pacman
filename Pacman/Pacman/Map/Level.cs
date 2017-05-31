using Pacman.Entities;
using Pacman.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman.KeyInput;

namespace Pacman.Map
{
    public class Level : IRenderable
    {
        public Tile[] Grid { get; private set; }

        public Renderer LevelRenderer { get; private set; }

        public Player Player { get; private set; }

        public Form Form { get; private set; }

        public KeyInputHandler KeyInputHandler { get; private set; }

        public Level(Form form, Control parent, LevelDecoder decoder)
        {
            Form = form;
            KeyInputHandler = new KeyInputHandler(form, true, ThreadingMode.None);
            EventKeyInput eventKeyInput = new EventKeyInput();
            eventKeyInput.KeyInput += EventKeyInput_KeyInput;
            KeyInputHandler.RegisterKeyInput(eventKeyInput);
            KeyInputHandler.Start();
            form.FormClosing += Form_FormClosing;
            //Grid = decoder.DecodeLevel();
            LevelRenderer = new Renderer(parent, this);
            Player = new Player(parent, this, decoder.Width / 32, decoder.Height / 32);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyInputHandler.Stop();
        }

        private void EventKeyInput_KeyInput(IKeyInput sender, Keys key)
        {
            Player.Move(key);
        }

        public void Render(Graphics g)
        {
        }

        public Tile GetTile(int x, int y)
        {
            if (Grid == null)
                return null;
            foreach (Tile tile in Grid)
                if (tile.X == x && tile.Y == y)
                    return tile;
            return null;
        }
    }
}
