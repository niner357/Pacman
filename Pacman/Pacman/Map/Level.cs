using Pacman.Entities;
using Pacman.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Map
{
    public class Level : IRenderable
    {
        public Tile[] Grid { get; private set; }

        public Renderer LevelRenderer { get; private set; }

        public Player Player { get; private set; }

        public Level(Control parent, LevelDecoder decoder)
        {
            //Grid = decoder.DecodeLevel();
            LevelRenderer = new Renderer(parent, this);
            Player = new Player(parent, this, decoder.Width / 32, decoder.Height / 32);
        }

        public void Render(Graphics g)
        {

        }

        public Tile GetTile(int x, int y)
        {
            foreach (Tile tile in Grid)
                if (tile.X == x && tile.Y == y)
                    return tile;
            return null;
        }
    }
}
