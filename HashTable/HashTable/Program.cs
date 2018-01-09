using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {

            Hash<int> hashtable = new Hash<int>();


            for (int i = 0; i < hashtable.size; i++)
            {
                hashtable.addvalue(i*i, i);
            }

            Console.WriteLine(hashtable.getvalue(1));
            Console.WriteLine(hashtable.getvalue(454));
            Console.WriteLine(hashtable.getvalue(213));
            Console.WriteLine(hashtable.getvalue(16));
        }
    }
}
