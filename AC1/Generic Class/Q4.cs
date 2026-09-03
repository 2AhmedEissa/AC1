using System;
using System.Collections.Generic;
using System.Text;

namespace AC1.Generic_Class
{


    //Q3 Generic classes that can have multiple type parameters. 

    internal class Q4
    {
        public void Swap<T>(ref T a, ref T b)
        {
            T temp = a;

            a = b;

            b = temp;
        }
        //Q5
        public T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}
