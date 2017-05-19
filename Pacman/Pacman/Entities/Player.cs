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
        public int x, y, pWidth, pHeight;

        public Player(Control parent)
        {
            PlayerRenderer = new Renderer(parent, this);
        }

        public void Spawn(int x, int y, int pWidth, int pHeight)
        {
            this.x = x;
            this.y = y;
            this.pWidth = pWidth;
            this.pHeight = pHeight;
            PlayerRenderer.DoRender(x, y);
        }

        public void Render(Graphics g)
        {
            
        }

        public void OpenPacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), x, y, pWidth, pHeight);
            g.FillPie(new SolidBrush(Color.Black), x, y, pWidth, pHeight, -40, 80);
        }

        public void ClosePacMan(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), x, y, pWidth, pHeight);
        }
    }
}
