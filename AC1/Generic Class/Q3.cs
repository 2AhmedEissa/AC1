using System;
using System.Collections.Generic;
using System.Text;

namespace AC1.Generic_Class
{


    //Q3 Generic classes that can have multiple type parameters. 

    internal class Q3<T1, T2>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }

        public Q3(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Key}: {Value}";
        }
    }
}
