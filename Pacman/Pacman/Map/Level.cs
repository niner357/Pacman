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

        public Level(Control parent, LevelDecoder decoder)
        {
            Grid = decoder.DecodeLevel();
            LevelRenderer = new Renderer(parent, this);
        }

        public void Render(Graphics g)
        {

        }
    }
}
