using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Collision
{
    public interface ICollidable
    {
        void OnCollide(CollideResult result);
    }
}
