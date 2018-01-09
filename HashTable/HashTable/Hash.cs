using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    
    class Hash<T> 
    {

        
        Dictionary<int, Tuple<int,T>> dictionary = new Dictionary<int, Tuple<int, T>>();

        public int size = 1000;

        public void addvalue(int key, T value)
        {
            Console.WriteLine("dictionary count: " + dictionary.Count);
            if (dictionary.Count >= size)
            {
                Console.WriteLine("dictionary full");
                return;
            }

            int place = Hashfunction(key); 


            if(place == -1)
            {
                Console.WriteLine("something went wrong");
                return;
            }

            Console.WriteLine("place: " + place + " Key: " + key + " Value:" + value);

            dictionary.Add(place, new Tuple<int, T>(key, value));
                
        }

        public T getvalue(int key)
        {

            int place = Hashfunction(key);

            Console.WriteLine("get value:" + place);

            if (!dictionary.ContainsKey(place))
            {
                Console.WriteLine(" doesnt exist");
                return default(T);
            }

            return dictionary[place].Item2;

        }


        public int Hashfunction(int key)
        {
            int place = key % size;

            for(int i = 0; i < size; i++) {

                if (dictionary.ContainsKey(place))
                {
                    //Console.WriteLine("place taken +1 spot");
                    if (dictionary[place].Item1 == key)
                    {
                        return place;
                    }
                    else
                    {
                        place = (place + 1) % size;
                    }
                }

                else
                {
                    return place;
                }

            }

            return -1;
        }
    }
}
