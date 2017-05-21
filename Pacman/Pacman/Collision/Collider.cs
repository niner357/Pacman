using Pacman.Entities;
using Pacman.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Collision
{
    public class Collider
    {
        public ICollidable Collidable { get; private set; }

        public Level Level { get; private set; }

        public Collider(Level level, ICollidable collidable)
        {
            Collidable = collidable;
            Level = level;
        }

        public void OnMove(int toX, int toY)
        {
            CollideResult result = CheckForCollision(toX, toY);
            if(result.Collision)
                Collidable.OnCollide(result);
        }

        private CollideResult CheckForCollision(int toX, int toY)
        {
            Tile tile = Level.GetTile(toX, toY);
            if (tile == null)
                return new CollideResult(true, CollisionType.Side);
            if (tile.Type == TileType.Wall)
                return new CollideResult(true, CollisionType.Wall);
            //TODO ENEMY COLLISION DETECTION
            return new CollideResult(false, CollisionType.None);
        }
    }
}
