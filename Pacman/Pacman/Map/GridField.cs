using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Map
{
    public class GridField
    {
        public bool Solid { get; set; }

        public int Width { get; }

        public int Height { get; }

        public int X { get; }

        public int Y { get; }

        public GridField(int x, int y)
        {
            Width = 16;
            Height = 16;
            X = x;
            Y = y;
            Solid = false;
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
