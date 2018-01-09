﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class DoubleListQueue<T>
    {
      

        public doublelist<T> list;
        // voeg lijst toe
        public DoubleListQueue(doublelist<T> list)
        {
            this.list = list.GetFirst(list);
        }

        //zet waarde eind van de lijst
        public doublelist<T> Enqueue(T value)
        {
            this.list.InsertLast(list, value);
            return this.list;
            
        }

        //verwijderd waarde begin van de lijst
        public doublelist<T> Dequeue()
        {

            this.list = this.list.Next;
            this.list.Prev = new DoubleEmpty<T>();
            return this.list;

        }
        // laat waarde zien
        public T Peek()
        { 
            return this.list.Value;
        }


    }


    class DoubleListStack<T>
    {
        public doublelist<T> list;
        // zet lijst
        public DoubleListStack(doublelist<T> list)
        {
            this.list = list.GetFirst(list);
        }

        //zet nieuwe waarde begin lijst
        public doublelist<T> Push(T value)
        {   //pleurt nieuwe waarde in en zet begin van de lijst naar die waarde
            this.list = this.list.InsertBeginning(this.list, value);
            return this.list;
        }
        //verwijderd waarde begin lijst
        public doublelist<T> Pop()
        {
            this.list = this.list.Next;
            this.list.Prev = new DoubleEmpty<T>();
            return this.list;

        }
        // check waarde
        public T Peek()
        {
            return this.list.Value;
        }


    }
}
