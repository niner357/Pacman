using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace RunLengthEncoding.Pathfinding
{
    public class Graph
    {
        public List<Node> Nodes { get; private set; }

        public int[,] Matrix { get; private set; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public void InitizializeMatrix()
        {
            Matrix = new int[Nodes.Count, Nodes.Count];
            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes.Count; j++)
                {
                    int distX = Nodes[i].X - Nodes[j].X;
                    int distY = Nodes[i].Y - Nodes[j].Y;
                    int dist = distX * distX + distY * distY;
                    if (dist == 1) AddBorder(i, j);
                }
            }
        }

        public void AddNode(GridField field)
        {
            Nodes.Add(new Node(field));
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        private void AddBorder(int from, int to)
        {
            Matrix[from,to] = 1;
            Matrix[to,from] = 1;
        }

        private int GetNextNode()
        {
            int id = -1;
            int value = int.MaxValue;
            for(int i = 0; i < Nodes.Count; i++)
            {
                if(!Nodes[i].Visited && Nodes[i].GetValue() < value)
                {
                    id = i;
                    value = Nodes[i].GetValue();
                }
            }
            return id;
        }

        public List<Node> AStarDijkstra(Point start, Point end)
        {
            int currentNode, newDist, maxValue = (int.MaxValue - (int)Math.Sqrt(32 * 32 + 32 * 32));
            for(int i = 0; i < Nodes.Count; i++)
            {
                int distX = Nodes[i].X - Nodes[GetId(GetNode(end))].X;
                int distY = Nodes[i].Y - Nodes[GetId(GetNode(end))].Y;
                Nodes[i].Heuristic = (int)Math.Sqrt(distX * distX + distY * distY);
                Nodes[i].Visited = false;
                Nodes[i].Range = maxValue;
            }
            Nodes[GetId(GetNode(start))].Range = 0;
            bool _break = false;
            for(int i = 0; i < Nodes.Count; i++)
            {
                if (!_break)
                {
                    currentNode = GetNextNode();
                    if (currentNode == -1) break;
                    Nodes[currentNode].Visited = true;
                    for (int br = 0; br < Nodes.Count; br++)
                    {
                        if (!Nodes[br].Visited && Matrix[br, currentNode] > 0)
                        {
                            newDist = Nodes[currentNode].Range + Matrix[br, currentNode];
                            if (newDist < Nodes[br].Range)
                            {
                                Nodes[br].Range = newDist;
                                Nodes[br].Parent = Nodes[currentNode];
                                if (br == GetId(GetNode(end)))
                                {
                                    _break = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            List<Node> path = new List<Node>();
            currentNode = GetId(GetNode(end));
            path.Add(Nodes[currentNode]);
            bool result = true;
            while(currentNode != GetId(GetNode(start)))
            {
                currentNode = GetId(Nodes[currentNode].Parent);
                if (currentNode == -1)
                {
                    result = false;
                    break;
                }
                path.Add(Nodes[currentNode]);
            }
            if(!result)
            {
                path.Clear();
                return path;
            }
            return path;
        }

        private int GetId(Node node)
        {
            int i = 0;
            foreach (Node _node in Nodes)
            {
                if (_node == node)
                    return i;
                i++;
            }
            return -1;
        }

        private Node GetNode(Point pt)
        {
            foreach (Node node in Nodes)
                if (node.X == pt.X && node.Y == pt.Y)
                    return node;
            return null;
        }
    }
}
