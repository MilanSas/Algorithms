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
            Node<int> emptyNode = new EmptyNode<int>();
            var binaryTree = new BinaryTree<int>(emptyNode);

            binaryTree.Insert(5);
            binaryTree.Insert(7);
            binaryTree.Insert(6);
            binaryTree.Insert(4);
            binaryTree.Insert(13);
            binaryTree.Insert(9);
            binaryTree.Insert(2);
            binaryTree.Insert(1);
            binaryTree.Insert(3);
            binaryTree.Insert(69);
            binaryTree.printnodes();
            binaryTree.Delete(5);
            binaryTree.printnodes();
            binaryTree.Delete(6);
            binaryTree.printnodes();
            binaryTree.Delete(7);
            binaryTree.printnodes();
          

        }
    }
}
