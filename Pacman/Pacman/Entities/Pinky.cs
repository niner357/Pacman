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
    class Pinky : IRenderable, ICollidable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Collider PinkyCollider { get; private set; }

        private Level level;
        private RendererPanel renderer;

        public Pinky(RendererPanel renderer, Level level, int width, int height)
        {
            this.level = level;
            this.renderer = renderer;
            PinkyCollider = new Collider(level, this);
            this.Width = width;
            this.Height = height;
        }

        public void OnCollide(CollideResult result)
        {
            throw new NotImplementedException();
        }

        public void OnNoneCollide(int toX, int toY)
        {
            throw new NotImplementedException();
        }

        public void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
