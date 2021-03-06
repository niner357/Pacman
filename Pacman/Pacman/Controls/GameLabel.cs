﻿using Pacman.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Controls
{
    public class GameLabel : GameControl
    {
        public string Text { get; private set; }

        public float FontSize { get; private set; }

        public Color Color { get; private set; }

        public GameLabel(int id, string text, float size, Color color)
        {
            Id = id;
            Text = text;
            Color = color;
            FontSize = size;
            Width = TextRenderer.MeasureText(text, new FontManager().CreateFont(FontSize)).Width;
            Height = TextRenderer.MeasureText(text, new FontManager().CreateFont(FontSize)).Height;
        }

        public override void OnActivateRender(Graphics graphics)
        {
        }

        public override void OnEnterRender(Graphics graphics)
        {
        }

        public override void OnInitRender(Graphics graphics)
        {
            graphics.DrawString(Text, new FontManager().CreateFont(FontSize), new SolidBrush(Color), Location);
        }

        public override void OnLeaveRender(Graphics graphics)
        { 
        }
    }
}
