using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    
    {   
        // walks through graph breath first
        static void BFS(List<Node> nodelist, Node root, Action<Node> act) //Don't know how Graph parameter is normally structured. So I am using lists for resetting and root as entry to Graph.
        {

            foreach(Node n in nodelist) // resets visited value
            {
                n.visited = false;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root); 
            while (!queue.isempty())
            {
                Node current = queue.Dequeue();   //gets the first node in queue and deletes it 

                if (!current.visited)
                {
                    current.Visit();            // visits itself so it isn't called again if placed in queue
                    act(current);              // does something with the node
                    foreach (Node n in current.Adjacentnodes)
                    {
                            queue.Enqueue(n);  // enqueues all neighbours                 
                    }
                }              
            }
        }
        
        // walks through graph depth first
        static void DFS(List<Node> nodelist, Node root, Action<Node> act) 
        {

            foreach (Node n in nodelist) // resets visited values
            {
                n.visited = false;
            }

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (!stack.isempty())
            {
                Node current = stack.Pop();
                current.Adjacentnodes.Reverse();
                if (!current.visited)
                {   
                    current.Visit();
                    act(current);
                    foreach (Node n in current.Adjacentnodes)
                    {
                        stack.Push(n);
                    }
                }
            }
        }

    static void Dijkstra(List<Node>nodelist, Node root)
        {
            //set all distances from root 
            List<Node> Nodelist = new List<Node>();
            foreach(Node node in nodelist)         
            {
                Nodelist.Add(node);
                if (!root.Distances.ContainsKey(node))
                {
                    root.Distances[node] = int.MaxValue;
                    node.bestpath[root] = null;
                }
            }

            root.Distances[root] = 0; //forces first selectednode to be the root


            while (Nodelist.Count > 0)
            {
                Node selectednode = root;
                selectednode = selectednode.MinDistanceToNode(Nodelist); // selects node with minimal costs (I am not using queue because you don't know all the costs so you don't know the order)
                Console.WriteLine(selectednode.Letter);                  // prints node so you can see the path it takes
                Nodelist.Remove(selectednode);                           // removes the selected node from lists
                
                foreach(Node neighbour in selectednode.Adjacentnodes)
                {
                    // Normally you would calculate the costs between neighbour nodes here. But I calculated those beforehand
                    int alt = root.Distances[selectednode] + selectednode.Distances[neighbour];
                    
                    //for not going negative if value gets over int cap
                    if (root.Distances[selectednode] == int.MaxValue || selectednode.Distances[neighbour] == int.MaxValue)
                    {
                        alt = int.MaxValue;
                    }

                    // replaces distance if found a shorter path
                    else if (alt < root.Distances[neighbour])
                    {
                        root.Distances[neighbour] = alt;
                        root.bestpath[neighbour] = selectednode;
                    }
                }
            }
        }
            
        static void Main(string[] args)
        {   
            // uses graph examples from Github hogeschool Development 6a Graphs
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

            List<Node> graph = new List<Node>() { A, B, C, D, E, F, G, H, I, J, K, L };

            Console.WriteLine("Bfs order:");
            BFS(graph, A, (n) => Console.WriteLine(n.Letter));
            Console.WriteLine("Dfs order:");
            DFS(graph, A, (n) => Console.WriteLine(n.Letter));


            // Graph example Hogeschool Dev6a/
            Node A2 = new Node("A");
            Node B2 = new Node("B");
            Node C2 = new Node("C");
            Node D2 = new Node("D");
            Node E2 = new Node("E");
            Node F2 = new Node("F");


            A2.addNode(B2, 8);
            A2.addNode(C2, 1);
            B2.addNode(D2, 2);
            C2.addNode(D2, 3);
            D2.addNode(E2, 4);
            D2.addNode(F2, 6);
            E2.addNode(F2, 1);

           List<Node> nodelist = new List<Node> {A2, B2, C2, D2, E2, F2 };

            Console.WriteLine("Order dijkstra through graph: ");
            Dijkstra(nodelist, A2);
            Dijkstra(nodelist, F2);

            Console.WriteLine("Distance to point A to B: " + A2.getDistance(B2));
            Console.WriteLine("Distance to point F to A: " + F2.getDistance(A2));

            //puts path in reverse, from the destination to start improvements welcome
            Console.WriteLine("best path to A from B");
            A2.Bestpath(B2);
            Console.WriteLine("best path to F from A");
            F2.Bestpath(A2);

        }
    }
}
