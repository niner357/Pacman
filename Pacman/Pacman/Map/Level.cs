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

        public Renderer Renderer { get; private set; }

        public Player Player { get; private set; }

        public Form Form { get; private set; }

        public KeyInputHandler KeyInputHandler { get; private set; }

        public RendererPanel RendererPanel { get; private set; }

        public Level(Form form, LevelDecoder decoder)
        {
            Form = form;
            RendererPanel = new RendererPanel(Render);
            RendererPanel.Width = 512;
            RendererPanel.Height = 512;
            RendererPanel.Location = new Point(0, 0);
            Player = new Player(RendererPanel, this, RendererPanel.Width / 32, RendererPanel.Height / 32);
            RendererPanel.PlayerRenderAction = Player.Render;
            RendererPanel.DoRender();
            form.Controls.Add(RendererPanel);
            KeyInputHandler = new KeyInputHandler(form, true, ThreadingMode.None);
            EventKeyInput eventKeyInput = new EventKeyInput();
            eventKeyInput.KeyInput += EventKeyInput_KeyInput;
            KeyInputHandler.RegisterKeyInput(eventKeyInput);
            KeyInputHandler.Start();
            form.FormClosing += Form_FormClosing;
            Grid = decoder.DecodeLevel();
            Player.Spawn(16, 16);
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
            foreach (Tile tile in Grid)
            {
                switch (tile.Type)
                {
                    case TileType.Wall:
                        g.FillRectangle(new SolidBrush(Color.Blue), tile.X, tile.Y, tile.Width, tile.Height);
                        continue;
                    case TileType.Way:
                        g.FillRectangle(new SolidBrush(Color.Black), tile.X, tile.Y, tile.Width, tile.Height);
                        continue;
                }
            }
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
