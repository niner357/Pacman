using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Rendering
{
    public class Renderer
    {
        public Control Control { get; private set; }

        public IRenderable Renderable { get; private set; }

        private Bitmap bufferBitmap;
        private Graphics bufferGraphics;
        private Graphics screenGraphics;

        public Renderer(Control control, IRenderable renderable)
        {
            Control = control;
            Renderable = renderable;
            bufferBitmap = new Bitmap(control.Width, Control.Height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = control.CreateGraphics();
        }

        public Renderer(Control control, IRenderable renderable, int width, int height)
        {
            Control = control;
            Renderable = renderable;
            bufferBitmap = new Bitmap(width, height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = control.CreateGraphics();
        }

        public void DoRender()
        {
            Renderable.Render(bufferGraphics);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
        }

        public void DoRender(int x, int y)
        {
            Renderable.Render(bufferGraphics);
            screenGraphics.DrawImage(bufferBitmap, x, y);
        }
    }
}
