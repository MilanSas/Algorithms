using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Queue<T>
    {
        List<T> queue = new List<T>();

        public bool isempty()
        {
            return queue.Count() == 0;
        }
        public Queue()
        {

        }

        public T Dequeue()
        {
            T result = this.Peek();
            this.queue = queue.Skip(1).ToList();
            return result;

        }

        public void Enqueue(T value)
        {
            queue.Add(value);
        }

        public T Peek()
        {
            return queue[0];
        }
    }

    class Stack<T>
    {
        List<T> stack = new List<T>();

        public bool isempty()
        {
            return stack.Count() == 0;
        }

        public Stack() { }

        public T Pop()
        {
            T result = Peek();
            stack.Remove(result);
            return result;
        }

        public void Push(T value)
        {
            stack.Insert(0, value);
        }

        public T Peek()
        {   
            return stack[0];
        }
    }
}
