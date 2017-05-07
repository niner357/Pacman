using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RunLengthEncoding.Controls
{
    public abstract class GameControl
    {
        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Point Location { get; set; }

        public abstract void OnInitRender(Graphics graphics);
        public abstract void OnActivateRender(Graphics graphics);
        public abstract void OnEnterRender(Graphics graphics);
        public abstract void OnLeaveRender(Graphics graphics);
    }
}
