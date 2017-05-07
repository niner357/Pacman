using System;
using System.Collections.Generic;
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
    }
}
