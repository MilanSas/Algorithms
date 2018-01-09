using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmes
{
    class Program
    {   public static bool InListLinear(int value, List<int> intlist)
        {
            foreach (int number in intlist)
            {
                if (number == value)
                {
                    return true;
                }
            }

            return false;
        }

        public static int InListBinary(int value, List<int> intlist)
        {
            int low = 0;
            int high = intlist.Count - 1;

            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (value < intlist[middle])
                {
                    high = middle -1;
                }

                else if (value > intlist[middle])
                {
                    low = middle + 1;
                }

                else
                {
                    return middle;
                }


            }

            return -1;

        }
        static void Main(string[] args)
        {
            List<int> intlist1 = new List<int>() { 1, 2, 32, 38, 234, 1234, 9909};
            bool result = InListLinear(38, intlist1);
            Console.WriteLine(result);

            int result1 = InListBinary(234, intlist1);
            Console.WriteLine(result1);
        }
    }
}
