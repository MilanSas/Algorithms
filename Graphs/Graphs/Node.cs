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
                node.addNode(this, distance);
            }
        }

        public void Visit()
        {
            Console.WriteLine(Letter);
            this.visited = true;
        }

    }
}
