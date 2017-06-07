using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pacman.Rendering;
using Pacman.Collision;
using System.Drawing;
using Pacman.Map;

namespace Pacman.Entities
{
    public class Pinky : IRenderable, ICollidable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Collider PinkyCollider { get; private set; }

        private Level level;
        private RendererPanel renderer;
        private int directionAddX, directionAddY;

        public Pinky(RendererPanel renderer, Level level, int width, int height)
        {
            this.level = level;
            this.renderer = renderer;
            PinkyCollider = new Collider(level, this);
            this.Width = width;
            this.Height = height;
            Random eyeDirection = new Random();
            int i = eyeDirection.Next(1, 5);
            int eyeSizeX = Width * 19 / 100;
            int eyeSizeY = Height * 19 / 100;
            if (i == 1)
            {
                directionAddX = 0;
                directionAddY = eyeSizeY / 4;
            }
            if(i == 2)
            {
                directionAddX = eyeSizeX / 4;
                directionAddY = 0;
            }
            if(i == 3)
            {
                directionAddX = eyeSizeX / 2;
                directionAddY = eyeSizeY / 4;
            }
            if(i == 4)
            {
                directionAddX = eyeSizeX / 4;
                directionAddY = eyeSizeY / 2;
            }
        }

        public void OnCollide(CollideResult result)
        {
            throw new NotImplementedException();
        }

        public void OnNoneCollide(int toX, int toY)
        {
            throw new NotImplementedException();
        }

        public void Spawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
            renderer.DoRender();
        }

        public void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width / 8, Y, (Width * 3) / 4, Height / 2));
            g.FillRectangle(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width / 8, Y + Height / 4, (Width * 3) / 4, (Height * 5) / 8));
            g.FillEllipse(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width / 8, Y + (Height * 3) / 4, Width / 4, Height / 4));
            g.FillEllipse(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width / 4, Y + (Height * 3) / 4, Width * 6 / 25, Height * 6 / 25));
            g.FillEllipse(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width * 3 / 8, Y + (Height * 3) / 4, Width / 4, Height / 4));
            g.FillEllipse(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width / 2, Y + (Height * 3) / 4, Width * 6 / 25, Height * 6 / 25));
            g.FillEllipse(new SolidBrush(Color.MediumPurple), new Rectangle(X + Width * 5 / 8, Y + (Height * 3) / 4, Width / 4, Height / 4));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(X + Width / 4, Y + Height / 4, Width * 19 / 100, Height * 19 / 100));
            g.FillEllipse(new SolidBrush(Color.DarkBlue), new Rectangle(X + Width / 4 + directionAddX, Y + Height / 4 + directionAddY, Width * 19 / 200, Height * 19 / 200));
            g.FillEllipse(new SolidBrush(Color.White), new Rectangle(X + Width * 14 / 25, Y + Height / 4, Width * 19 / 100, Height * 19 / 100));
            g.FillEllipse(new SolidBrush(Color.DarkBlue), new Rectangle(X + Width * 14 / 25 + directionAddX, Y + Height / 4 + directionAddY, Width * 19 / 200, Height * 19 / 200));
        }
    }
}
