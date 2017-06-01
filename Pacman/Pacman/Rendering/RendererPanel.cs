using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Rendering
{
    public class RendererPanel : Panel
    {
        public Action<Graphics> PlayerRenderAction { get; set; }
        public Action<Graphics> WorldRenderAction { get; private set; }

        public RendererPanel(Action<Graphics> worldRenderAction)
        {
            WorldRenderAction = worldRenderAction;
            BackColor = Color.Black;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            WorldRenderAction(e.Graphics);
            if (PlayerRenderAction != null)
                PlayerRenderAction(e.Graphics);
        }

        public void DoRender()
        {
            Invalidate();
        }
    }
}
