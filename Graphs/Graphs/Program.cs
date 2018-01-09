using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {   static void BFS(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (!queue.isempty())
            {
                Node current = queue.Dequeue();

                if (!current.visited)
                {
                    current.Visit();
                    foreach (Node n in current.Adjacentnodes)
                    {
                            queue.Enqueue(n);                    
                    }
                }              
            }
        }

        static void DFS(Node root)
        {
            Stack<Node> stack = new Stack<Node>();

            stack.Push(root);

            while (!stack.isempty())
            {
                Node current = stack.Pop();
                current.Adjacentnodes.Reverse();
                if (!current.visited)
                {
                    current.Visit();
                    foreach (Node n in current.Adjacentnodes)
                    {
                        stack.Push(n);
                    }
                }
            }
        }
            
        static void Main(string[] args)
        {
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");
            Node G = new Node("G");
            Node H = new Node("H");
            Node I = new Node("I");
            Node J = new Node("J");
            Node K = new Node("K");
            Node L = new Node("L");

            A.addNode(B, 2);
            A.addNode(C, 3);
            A.addNode(D, 2);
            B.addNode(E, 4);
            B.addNode(F, 2);
            D.addNode(G, 5);
            D.addNode(H, 3);
            E.addNode(I, 8);
            E.addNode(J, 7);
            G.addNode(K, 5);
            G.addNode(L, 3);

            BFS(A);
            //DFS(A);

        }
    }
}
