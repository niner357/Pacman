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

        public IRenderable PlayerRenderable { get; private set; }
        public IRenderable LevelRenderable { get; private set; }

        private Bitmap bufferBitmap;
        private Graphics bufferGraphics;
        private Graphics screenGraphics;

        public Renderer(Control control, IRenderable playerRenderable, IRenderable lvlRenderable)
        {
            Control = control;
            PlayerRenderable = playerRenderable;
            LevelRenderable = lvlRenderable;
            bufferBitmap = new Bitmap(control.Width, Control.Height);
            bufferGraphics = Graphics.FromImage(bufferBitmap);
            screenGraphics = control.CreateGraphics();
        }

        public void DoWorldRender()
        {
            LevelRenderable.Render(bufferGraphics);
            screenGraphics.DrawImage(bufferBitmap, 0, 0);
        }

        public void DoPlayerRender(int x, int y)
        {
            PlayerRenderable.Render(bufferGraphics);
            screenGraphics.DrawImage(bufferBitmap, x, y);
        }

        public void Clear(int x, int y)
        {
            bufferGraphics.Clear(Color.Black);
            screenGraphics.DrawImage(bufferBitmap, x, y);
        }

        public void Clear()
        {
            Clear(0, 0);
        }
    }
}
