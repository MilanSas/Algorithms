using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algoritme
{
    
    class Program
    {

        public static List<int> insertionsort(List<int> list){

            for(int listindex = 2; listindex < list.Count(); listindex++)
            { 
                int value = list[listindex];
                int currentindex = listindex - 1;
                

                while (currentindex > 0 && list[currentindex] > value)
                {
                    
                    list[currentindex + 1] = list[currentindex];
                    currentindex = currentindex - 1;
                }

                list[currentindex + 1] = value;
            }
            return list;
        }

        public static void Merge(List<int> list, int begin, int mid, int end)
        {
            int n1 = mid - begin + 1;
            int n2 = end - mid;

            List<int> list1 = list.GetRange(begin, n1);
            List<int> list2 = list.GetRange(mid+1 , n2);

            list1.Add(int.MaxValue);
            list2.Add(int.MaxValue);

            int index1 = 0;
            int index2 = 0;

            for (int i = begin; i <= end; i++)
            {
                if (list1[index1] <= list2[index2])
                {
                    list[i] = list1[index1];
                    index1++;
                }

                else
                {
                    list[i] = list2[index2];
                    index2++;
                }
            }

        }

        public static void Mergesort(List<int> list, int begin, int end)
        {
            if (begin < end)
            {
                int mid = (begin + end) / 2;
                Mergesort(list, begin, mid);
                Mergesort(list, mid+1, end);
                Merge(list, begin, mid, end);
            }

            else
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 2, 7, 245, 1234, 3, 6, 5, 43, 9 };

            //List<int> list2 = insertionsort(list1);

            //IEnumerable<int> list3 = list2.Where(value => value % 2 == 0);

            Mergesort(list1, 0, list1.Count()-1);

            foreach(int value in list1)
            {
                Console.WriteLine(value);
            }
                
        }
    }
}
