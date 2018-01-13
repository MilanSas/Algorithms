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
            var binaryThree = new BinaryThree<int>(emptyNode);

            binaryThree.Insert(5);
            binaryThree.Insert(7);
            binaryThree.Insert(6);
            binaryThree.Insert(4);
            binaryThree.Insert(13);
            binaryThree.Insert(9);
            binaryThree.Insert(2);
            binaryThree.Insert(1);
            binaryThree.Insert(3);
            binaryThree.Insert(69);
            binaryThree.printnodes();
            binaryThree.Delete(5);
            binaryThree.printnodes();
            binaryThree.Delete(6);
            binaryThree.printnodes();
            binaryThree.Delete(7);
            binaryThree.printnodes();
          

        }
    }
}
