using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> BinaryTree = new EmptyNode<int>();

            BinaryTree = BinaryTree.Insert(6);
            BinaryTree = BinaryTree.Insert(8);
            BinaryTree = BinaryTree.Insert(7);
            BinaryTree = BinaryTree.Insert(3);
            BinaryTree = BinaryTree.Insert(5);
            BinaryTree = BinaryTree.Insert(4);
            BinaryTree.printnodes();
            Node<int> Searchednode = BinaryTree.Search(0);
            Searchednode.printnodes();
            BinaryTree = BinaryTree.Delete(6);
            BinaryTree.printnodes();


        }
    }
}
