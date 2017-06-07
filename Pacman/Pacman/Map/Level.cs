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
            foreach (Tile Block in Grid)
            {
                switch(Block.Type)
                {
                    case TileType.Wall:
                        g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(Block.X, Block.Y, Block.Width, Block.Height));
                        break;

                    case TileType.Way:
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Block.X, Block.Y, Block.Width, Block.Height));
                        if (Block.Child != null)
                        {
                            if (Block.Child.Type == TileType.Point)
                            {
                                g.FillEllipse(new SolidBrush(Color.BurlyWood), new Rectangle(Block.X + Block.Width / 4, Block.Y + Block.Height / 4, Block.Width / 2, Block.Height / 2));
                            }
                        }
                        if(Player.X == Block.X && Player.Y == Block.Y)
                        {
                            Block.Child = null;
                        }
                        break;
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
