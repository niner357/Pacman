using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Map
{
    public class Tile
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public Tile Child { get; set; }

        public TileType Type { get; set; }

        public Tile(int x, int y, int width, int height, TileType type)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Type = type;
        }

        public bool IsPositionIn(Point point)
        {
            for (int x = X; x < X + Width; x++)
            {
                for (int y = Y; y < Y + Height; y++)
                {
                    if (point.X == x && point.Y == y)
                        return true;
                }
            }
            return false;
        }
    }
}
