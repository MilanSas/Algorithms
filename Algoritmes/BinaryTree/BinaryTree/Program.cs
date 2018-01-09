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

            BinaryTree = BinaryTree.Insert(5);
            BinaryTree = BinaryTree.Insert(7);
            BinaryTree = BinaryTree.Insert(6);
            BinaryTree = BinaryTree.Insert(4);
            BinaryTree = BinaryTree.Insert(13);
            BinaryTree = BinaryTree.Insert(9);
            BinaryTree = BinaryTree.Insert(2);
            BinaryTree = BinaryTree.Insert(1);
            BinaryTree = BinaryTree.Insert(3);
            BinaryTree = BinaryTree.Insert(69);
            BinaryTree.printnodes();
            BinaryTree = BinaryTree.Delete(5);
            BinaryTree.printnodes();
            BinaryTree = BinaryTree.Delete(6);
            BinaryTree.printnodes();
            BinaryTree = BinaryTree.Delete(7);
            BinaryTree.printnodes();


        }
    }
}
