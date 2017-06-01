using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Collision
{
    public class CollideResult
    {
        public bool Collision { get; private set; }

        public CollisionType Type { get; private set; }

        public CollideResult(bool collision, CollisionType type)
        {
            Collision = collision;
            Type = type;
        }
    }
}
