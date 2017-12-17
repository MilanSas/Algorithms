using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{   
    interface Node<T>
    {   //Most of these methods are only used in BinaryNode class. Improvements welcome
        Node<T> Right { get; set; }
        Node<T> Left { get; set; }
        Node<T> Parent { get; set; }
        Node<T> Insert(T value);
        Node<T> Delete(T value);
        Node<T> FindMostLeft();
        Node<T> FindMostRight();
        Node<T> Search(T value);
        Node<T> getRoot();
        T getvalue();
        void printnodes();
        bool isempty();
    }

    class EmptyNode<T> : Node<T>
    {
        public Node<T> Right { get => this; set { } }
        public Node<T> Left { get => this; set { } }
        public Node<T> Parent { get => this; set { } }

        // if you want to delete value that doesn't exist
        public Node<T> Delete(T value)
        {
            throw new Exception("Cannot delete value that isn't there");
        }

        //Empty doesnt have left. Improvements welcome
        public Node<T> FindMostLeft()
        {
            return null;
        }
        //Empty doesnt have right. Improvements welcome
        public Node<T> FindMostRight()
        {
            return null;
        }
        //Empty doesnt have root. Improvements welcome
        public Node<T> getRoot()
        {
            return null;
        }
        //throws exeption
        public T getvalue()
        {
            throw new Exception("No value in tree");
        }
        //inserts node if tree is empty
        public Node<T> Insert(T value)
        {
            return new BinaryNode<T>(value, this, new EmptyNode<T>(), new EmptyNode<T>());
        }
        //returns if node is empty
        public bool isempty()
        {
            return true;
        }
        //prints empty when empty node is printed
        public void printnodes()
        {
            Console.WriteLine("empty");
        }
        // returns empty node if value not found
        public Node<T> Search(T value)
        {
            return this;
        }
    }

    class BinaryNode<T> : Node<T>
    {
        T Value;
        Node<T> parent;
        Node<T> left;
        Node<T> right;
        bool deletepredecessor;

        public Node<T> Right { get => this.right; set => this.right = value; }
        public Node<T> Left { get => this.left; set => this.left = value; }
        public Node<T> Parent { get => this.parent; set => this.parent = value; }

        //constructor
        public BinaryNode(T Value,Node<T> parent, Node<T> left, Node<T> right)
        {   //alternates between deleting predecessor and successor to keep tree more balanced
            this.deletepredecessor = true;
            this.parent = parent; 
            this.Value = Value;
            this.left = left;
            this.right = right;
        }
        //returns that it isn't empty
        public bool isempty()
        {
            return false;
        }
        //gets root of tree
        public Node<T> getRoot()
        {
            if (!this.parent.isempty())
            {
                return this.parent.getRoot();
            }

            return this;

        }
        //get value of node
        public T getvalue()
        {
            return Value;
        }

        //finds most left of tree
        public Node<T> FindMostLeft()
        {
            if (!this.left.isempty())
            {
                return this.left.FindMostLeft();
            }

            else
            {
                return this;
            }

        }
        //finds most right of tree
        public Node<T> FindMostRight()
        {
            if (!this.right.isempty())
            {
                return this.right.FindMostRight();
            }

            else
            {
                return this;
            }
        }

        public Node<T> Delete(T value)
        {
            //searches value in tree that needs to be deleted and calls delete on it
            if (!(Comparer<T>.Default.Compare(value, this.Value) == 0))
            {
                return this.Search(value).Delete(value);
            }

            //if node has two childeren
            else if (!this.right.isempty() && !this.left.isempty())
            {   //deletes predecessor
                if (deletepredecessor)
                {
                    this.deletepredecessor = false;
                    Node<T> predecessor = this.left.FindMostRight();
                    this.Value = predecessor.getvalue();
                    Console.WriteLine("deleted " + value);
                    return predecessor.Delete(this.Value);
                }
                //deletes successor
                else
                {
                    this.deletepredecessor = true;
                    Node<T> successor = this.right.FindMostLeft();
                    this.Value = successor.getvalue();
                    Console.WriteLine("deleted " + value);
                    return successor.Delete(this.Value);
                }
            }

            //if node has one child
            else if((!this.right.isempty() | !this.left.isempty()))
            {   //deletes left child
                if (!this.left.isempty())
                {
                    Console.WriteLine("deleted " + value);
                    this.Value = this.left.getvalue();
                    this.right = this.left.Right;
                    this.left = this.left.Left;
                    this.right.Parent = this;
                    this.left.Parent = this;

                    return this.getRoot();
                }
                //deletes right child
                else
                {
                    Console.WriteLine("deleted " + value);
                    this.Value = this.right.getvalue();
                    this.left = this.right.Left;
                    this.right = this.right.Right;
                    this.right.Parent = this;
                    this.left.Parent = this;
                    return this.getRoot();
                }

            }
            //if node has no childeren
            else
            {
                //if its only node returns empty
                if (this.parent.isempty())
                {
                    Console.WriteLine("deleted " + value);
                    return this.parent;
                }
                //if its the left child of its parent
                else if (object.ReferenceEquals(this.parent.Left, this))
                {
                    this.parent.Left = new EmptyNode<T>();
                }
                //if its the right child of its parent
                else
                {
                    this.parent.Right = new EmptyNode<T>();
                }
                Console.WriteLine("deleted " + value);
                return this.getRoot();
            }


        }
        //print all nodes in order
        public void printnodes()
        {

            if (!this.left.isempty())
            {
                this.left.printnodes();
            }

            Console.WriteLine(this.Value);

            if (!this.right.isempty())
            {
                this.right.printnodes();
            }

        }
        // insert node in order
        public Node<T> Insert(T value)
        {   // if its smaller go left in tree
            if(Comparer<T>.Default.Compare(value, this.Value) == -1)
            {
                if (this.left.isempty())
                {
                    this.left = new BinaryNode<T>(value, this, new EmptyNode<T>(), new EmptyNode<T>());
                    return this.getRoot();
                }

                else
                {
                    return this.left.Insert(value);
                }

            }
            // if its bigger go right in tree
            else
            {
                if (this.right.isempty())
                {
                    this.right = new BinaryNode<T>(value, this, new EmptyNode<T>(), new EmptyNode<T>());
                    return this.getRoot();
                }

                else
                {
                    return this.right.Insert(value);
                }

            }
        }
        //searches value
        public Node<T> Search(T value)
        {   //if value found return node
            if (Comparer<T>.Default.Compare(value, this.Value) == 0)
            {
                return this;
            }

            //if value is smaller check left node
            else if (Comparer<T>.Default.Compare(value, this.Value) == -1)
            {
                return this.left.Search(value);
            }
            //if value is bigger check right node
            else 
            {
                return this.right.Search(value);

            }
        }

    }
}
