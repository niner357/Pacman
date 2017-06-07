using Pacman.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pacman.Collision;
using Pacman.Map;

namespace Pacman.Entities
{
    class Blinky : IRenderable, ICollidable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Collider BlinkyCollider { get; private set; }

        private Level level;
        private RendererPanel renderer;

        public Blinky(RendererPanel renderer, Level level, int width, int height)
        {
            this.level = level;
            this.renderer = renderer;
            BlinkyCollider = new Collider(level, this);
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
