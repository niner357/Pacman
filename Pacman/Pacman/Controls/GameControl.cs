﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman.Controls
{
    public abstract class GameControl
    {
        public int Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Point Location { get; set; }

        public bool Visible { get; set; }

        public abstract void OnInitRender(Graphics graphics);
        public abstract void OnActivateRender(Graphics graphics);
        public abstract void OnEnterRender(Graphics graphics);
        public abstract void OnLeaveRender(Graphics graphics);
    }
}
