using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Rendering;
using System.Windows.Forms;

namespace Pacman.Entities
{
    class Player : IRenderable
    {
        public Renderer PlayerRenderer { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Player(Control parent, int width, int height)
        {
            PlayerRenderer = new Renderer(parent, this);
            this.Width = width;
            this.Height = height;
        }

        public void Spawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
            PlayerRenderer.DoRender(x, y);
        }

        public void Render(Graphics g)
        {
            
        }

        public void OpenPacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), X, Y, Width, Height);
            g.FillPie(new SolidBrush(Color.Black), X, Y, Width, Height, -40, 80);
        }

        public void ClosePacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), X, Y, Width, Height);
        }
    }
}
