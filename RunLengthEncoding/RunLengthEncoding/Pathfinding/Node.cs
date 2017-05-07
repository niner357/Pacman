using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLengthEncoding.Pathfinding
{
    public class Node
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public int Heuristic { get; set; }

        public int Range { get; set; }

        public Node Parent { get; set; }

        public bool Visited { get; set; }

        public bool Walkable { get; private set; }

        public Node(GridField field)
        {
            X = field.X / 16;
            Y = field.Y / 16;
            Walkable = field.Solid ? false : true;
        }

        public int GetValue()
        {
            return Range + Heuristic;
        }
    }
}
