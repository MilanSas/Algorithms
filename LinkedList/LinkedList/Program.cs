using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {   static void Printist<T>(doublelist<T> list)
        {
            string result = "";
            while (!list.IsEmpty() | !list.Next.IsEmpty())
            {
                result = result + list.Value.ToString() + " ";
                list = list.Next;
            }

            Console.WriteLine(result + "Empty");
        }
        static void Main(string[] args)
        {
            // maak lijst adden kan niet handmatig
            doublelist<int> doublelist1 = new DoubleNode<int>(4, new DoubleEmpty<int>(), new DoubleEmpty<int>());

            // add extra waardes
            doublelist1 = doublelist1.InsertBefore(doublelist1, 2);

            doublelist1 = doublelist1.InsertBefore(doublelist1, 8);

            doublelist1 = doublelist1.InsertAfter(doublelist1, 9);


            //maak stack en queue
            DoubleListQueue<int> queue = new DoubleListQueue<int>(doublelist1);
            DoubleListStack<int> stack = new DoubleListStack<int>(doublelist1);

            // maak nieuwe lijsten voor testen
            doublelist<int> queuelist = queue.list;
            doublelist<int> stacklist = stack.list;


            //print die shit

            Printist<int>(queuelist);

            queuelist = queue.Enqueue(5);

            Console.WriteLine("added 5 at back");

            Printist<int>(queuelist);

            Console.WriteLine("first value is " + queue.Peek());

            queuelist = queue.Dequeue();

            Console.WriteLine("deleted first value");

            Printist<int>(queuelist);



            Printist<int>(stacklist);
            Console.WriteLine("first value is " + stack.Peek());

            stacklist = stack.Pop();

            Console.WriteLine("deleted first value");

            Printist<int>(stacklist);

            stacklist = stack.Push(11);

            Console.WriteLine("added 11 at front");


            Printist<int>(stacklist);



            //oude delete functies om te testen moet nog wel werken als je wilt testen.

            doublelist1 = doublelist1.Delete(doublelist1, 9);
            Printist<int>(doublelist1);

            doublelist1 = doublelist1.Delete(doublelist1, 8);
            Printist<int>(doublelist1);

            doublelist1 = doublelist1.Delete(doublelist1, 2);
            Printist<int>(doublelist1);

            doublelist1 = doublelist1.Delete(doublelist1, 4);
            Printist<int>(doublelist1);

            doublelist1 = doublelist1.Delete(doublelist1, 5);
            Printist<int>(doublelist1);



        }
    }
}
