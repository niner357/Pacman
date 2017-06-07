using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelCreator
{
    public class Field
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public FieldType Type { get; set; }

        public FieldType SpecialType { get; set; }

        public Field(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsPositionIn(Point point)
        {
            for (int x = X; x < X + 16; x++)
            {
                for (int y = Y; y < Y + 16; y++)
                {
                    if (point.X == x && point.Y == y)
                        return true;
                }
            }
            return false;
        }
    }
}
