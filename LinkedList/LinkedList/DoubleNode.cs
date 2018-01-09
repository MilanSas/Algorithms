using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{

    interface doublelist<T>
    {   //interface wel beetje skir tho
        bool IsEmpty();
        T Value { get; }
        doublelist<T> Next { get; set; }
        doublelist<T> Prev { get; set; }
        doublelist<T> GetFirst(doublelist<T> list);
        doublelist<T> GetLast(doublelist<T> list);
        doublelist<T> InsertAfter(doublelist<T> list, T value);
        doublelist<T> InsertBefore(doublelist<T> list, T value);
        doublelist<T> InsertBeginning(doublelist<T> list, T value);
        doublelist<T> InsertLast(doublelist<T> list, T value);
        doublelist<T> Delete(doublelist<T> list, T value);
    }


    class DoubleEmpty<T> : doublelist<T>
    {   //heeft geen value
        public T Value { get => default(T); }
        // wanneer te ver gaat maakt nieuwe next en prev aan zodat geen null errors
        public doublelist<T> Next { get => new DoubleEmpty<T>(); set { } }
        public doublelist<T> Prev { get => new DoubleEmpty<T>(); set { } }
        // komt hier alleen om value te vinden en wanneer niet gevonden geeft de lijst dan terug.
        public doublelist<T> Delete(doublelist<T> list, T value)
        {
            return list;
        }

        // empty check
        public bool IsEmpty()
        {
            return true;
        }

        //de rest wordt niet echt gebruikt.
        //wist ff niet zo snel goed hoe je dit makkelijk doet met die interface. 
        //returned gewoon de list stel hij komt er perongelijk
        public doublelist<T> GetFirst(doublelist<T> list)
        {
            return list;
        }

        public doublelist<T> GetLast(doublelist<T> list)
        {
            return list;
        }

        public doublelist<T> InsertAfter(doublelist<T> list, T value)
        {
            return list;
        }

        public doublelist<T> InsertBefore(doublelist<T> list, T value)
        {
            return list;
        }

        public doublelist<T> InsertBeginning(doublelist<T> list, T value)
        {
           return list;
        }

        public doublelist<T> InsertLast(doublelist<T> list, T value)
        {
            return list;
        }



    }



    class DoubleNode<T> : doublelist<T>
    {   
        T value;
        doublelist<T> prev;
        doublelist<T> next;

        //constructor maar dat wist je al
        public DoubleNode(T value, doublelist<T> prev, doublelist<T> next)
        {   
            this.value = value;
            this.prev = prev;
            this.next = next;
        }
        // heeft value
        public T Value => value;
        // om van buiten next en prev te zetten
        public doublelist<T> Next { get => next; set => next = value; }
        public doublelist<T> Prev { get => prev; set => prev = value; }

        //empty check
        public bool IsEmpty()
        {
            return false;
        }

        // return eerste node
        public doublelist<T> GetFirst(doublelist<T> list)
        {
            if (!this.prev.IsEmpty())
            {
                return this.prev.GetFirst(list.Prev);
            }

            return this;
        }

        // return laaste node
        public doublelist<T> GetLast(doublelist<T> list)
        {
            if (!this.next.IsEmpty())
            {
                return this.next.GetLast(list.Next);
            }

            return this;
        }


        // verwijderd alle nodes met ingevulde waarde
        public doublelist<T> Delete(doublelist<T> list, T value)
        {

            // terug gaan naar begin van lijst zodat ik recursive kan deleten anders weet ik niet waar lijst begint.
            if (!this.prev.IsEmpty() && !list.Prev.IsEmpty())
            {   
                return this.prev.Delete(list.Prev, value);
            }

            //als eerste waarde gelijk verwijderd moet worden
            else if (this.value.Equals(value))
            {
                this.next.Prev = this.prev;
                this.prev.Next = this.next;

                if (this.prev.IsEmpty() && this.next.IsEmpty())
                {
                    return list.Prev;
                }
                return list.Next.Delete(list.Next, value);
            }


            // als volgende waarde verwijderd moet worden
            else if (!this.next.IsEmpty() & this.next.Value.Equals(value))
            {
                this.next = this.next.Next;
                this.next.Prev = this;
                return list.Delete(list, value);
            }

            // volgende node checken
            else
            {
                return this.next.Delete(list, value);
            }
        }

        // insert waarde gesorteerd maar begint vanaf achter en kijkt waar de waarde achter gezet kan worden
        public doublelist<T> InsertAfter(doublelist<T> list, T value)
        {
            // ga naar einde van de lijst
            if (!this.next.IsEmpty() && !list.Next.IsEmpty())
            {

                return this.next.InsertAfter(list.Next, value);
            }

            // als die gelijk na de laaste waarde gezet kan worden
            else if (Comparer<T>.Default.Compare(this.Value, value) == -1)
            {

                DoubleNode<T> newnode = new DoubleNode<T>(value, this, this.next);
                this.next = newnode;
                //zet lijst weer terug naar eerste waarde is chiller voor printen enzo kan ook ergens anders gedaan worden als je wilt
                return list.GetFirst(list);


            }

            //als waarde voor zich kleiner is dan zichzelf kan ook nog gelijk check toevoegen voor relatieve volgorde
            else if (this.prev.IsEmpty() | Comparer<T>.Default.Compare(this.prev.Value, value) == -1)
            {
                if (this.prev.IsEmpty())
                {
                    return InsertBeginning(list, value);
                }

                DoubleNode<T> newnode = new DoubleNode<T>(value, this.prev, this);
                this.prev.Next = newnode;
                this.prev = newnode;
                return list.GetFirst(list);
            }
            // recursive call checked vorige node
            return this.prev.InsertAfter(list, value);
        }

        // insert waarde gesorteerd vanaf begin van de lijst en kijkt waar de waarde voor gezet kan worden
        public doublelist<T> InsertBefore(doublelist<T> list, T value)
        {

            // terug naar begin van de lijst
            if (!this.prev.IsEmpty() && !list.Prev.IsEmpty())
            {
                return this.prev.InsertBefore(list.Prev, value);
            }
            // als die gelijk voor eerste waarde kan
            else if (Comparer<T>.Default.Compare(this.Value, value) == 1)
            {
                DoubleNode<T> newnode = new DoubleNode<T>(value, this.prev, this);
                this.prev = newnode;
                return list;
            }


            // als die voor volgende waarde moet
            else if (this.next.IsEmpty() | Comparer<T>.Default.Compare(this.next.Value, value) == 1)
            {
                if (this.next.IsEmpty())
                {
                    return InsertLast(list, value);
                }

                DoubleNode<T> newnode = new DoubleNode<T>(value, this, this.next);
                this.next.Prev = newnode;
                this.next = newnode;
                return list;
            }
            // recursive call om volgende in de lijst te checken
            return this.next.InsertBefore(list, value);
        }

        //insert waarde helemaal aan het begin maakt niet uit of gesorteerd is
        public doublelist<T> InsertBeginning(doublelist<T> list, T value)
        {
            if (!this.prev.IsEmpty() && !list.Prev.IsEmpty())
            {
                return this.prev.InsertBeginning(list.Prev, value);
            }

            else
            {
                DoubleNode<T> newnode = new DoubleNode<T>(value, this.prev, this);
                this.prev = newnode;
                return list;

            }
        }

        //insert waarde aan het eind maakt niet uit of het gesorteerd is
        public doublelist<T> InsertLast(doublelist<T> list, T value)
        {
            if (!this.next.IsEmpty() && !list.Next.IsEmpty())
            {
                return this.next.InsertLast(list.Next, value);
            }

            else
            {
                DoubleNode<T> newnode = new DoubleNode<T>(value, this, this.next);
                this.next = newnode;
                return list;

            }
        }
    }
}
