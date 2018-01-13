using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Node
    {   public List<Node> Adjacentnodes = new List<Node>();
        public Dictionary<Node, int> Distances = new Dictionary<Node, int>();
        public Dictionary<Node, Node> bestpath = new Dictionary<Node, Node>();
        public string Letter;
        public bool visited = false;
        public Node(string letter)
        {
            this.Letter = letter;
        }

        public void addNode(Node node, int distance)
        {
            if (!Adjacentnodes.Contains(node))
            {
                this.Adjacentnodes.Add(node);
                this.Distances.Add(node, distance);
                this.bestpath.Add(node, node);
                node.addNode(this, distance);
            }
        }

        public void Visit()
        {
            this.visited = true;
        }

        public Node MinDistanceToNode(List<Node> nodelist)
        {
            Node result = null;

            foreach(Node node in nodelist)
            {
                if (result == null)
                {
                    result = node;
                }

                else if(this.Distances[node] < this.Distances[result])
                {
                    result = node;
                } 
            }

            return result;
        }

        public void Bestpath(Node node)
        {
            if(node == this)
            {
                Console.WriteLine(this.Letter);
            }
            else if (bestpath[node] == null)
            {
                Console.WriteLine("No connection to node");
            }
            
            else
            {
                Console.WriteLine(this.Letter);
                bestpath[node].Bestpath(node);
            }
        }

        public int getDistance(Node node)
        {
            if (Distances[node] == int.MaxValue)
            {
                return -1;
            }

            else
            {
                return Distances[node];
            }
        }
    }
}
