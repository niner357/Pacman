using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace RunLengthEncoding.Controls
{
    public class TestButton : GameControl
    {
        public string Text { get; set; }

        public Font Font { get; set; }

        public TestButton(string name, Point loc, Size size)
        {
            Text = "";
            Name = name;
            Location = loc;
            Width = size.Width;
            Height = size.Height;
            Font = SystemFonts.DefaultFont;
            Form1.ControlManager.AddControl(this);
        }

        public override void OnActivateRender(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.DarkBlue), new Rectangle(Location, new Size(Width, Height)));
            SizeF size = GetStringSize(Text);
            int x = Width / 2 - (int)size.Width / 2;
            if (x < 0)
                x = 0;
            int y = Height / 2 - (int)size.Height / 2;
            if (y < 0)
                y = 0;
            graphics.DrawString(Text, Font, new SolidBrush(Color.Yellow), Location.X + x, Location.Y + y);
        }

        public override void OnEnterRender(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Aqua), new Rectangle(Location, new Size(Width, Height)));
            SizeF size = GetStringSize(Text);
            int x = Width / 2 - (int)size.Width / 2;
            if (x < 0)
                x = 0;
            int y = Height / 2 - (int)size.Height / 2;
            if (y < 0)
                y = 0;
            graphics.DrawString(Text, Font, new SolidBrush(Color.Yellow), Location.X + x, Location.Y + y);
        }

        public override void OnInitRender(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(Location, new Size(Width, Height)));
            SizeF size = GetStringSize(Text);
            int x = Width / 2 - (int)size.Width / 2;
            if (x < 0)
                x = 0;
            int y = Height / 2 - (int)size.Height / 2;
            if (y < 0)
                y = 0;
            graphics.DrawString(Text, Font, new SolidBrush(Color.Yellow), Location.X + x, Location.Y + y);
        }

        public override void OnLeaveRender(Graphics graphics)
        {
            OnInitRender(graphics);
        }

        private SizeF GetStringSize(string s)
        {
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                return graphics.MeasureString(s, Font);
            }
        }
    }
}
