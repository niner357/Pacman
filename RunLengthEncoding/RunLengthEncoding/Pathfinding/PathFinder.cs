using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RunLengthEncoding.Pathfinding
{
    public class PathFinder
    {
        public Graph Graph { get; private set; }

        public Point Start { get; private set; }

        public Point End { get; private set; }

        public PathFinder(List<GridField> map, Point start, Point end)
        {
            Start = start;
            End = end;
            Graph = new Graph();
            foreach(GridField field in map)
            {
                if(!field.Solid)
                    Graph.AddNode(field);
            }
            Graph.InitizializeMatrix();
        }

        public List<Point> FindPath()
        {
            List<Node> pathNodes = Graph.AStarDijkstra(Start, End);
            List<Point> path = new List<Point>();
            foreach(Node node in pathNodes)
            {
                path.Add(new Point(node.X, node.Y));
            }
            return path;
        }
    }
}
