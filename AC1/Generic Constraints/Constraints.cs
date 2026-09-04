using System;
using System.Collections.Generic;
using System.Text;

namespace AC1.Generic_Constraints
{

    #region Generic Constraints

    #region Q7

    internal class StructConstraint<T> where T : struct
    {
        public StructConstraint(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

    }




    #endregion

    #region Q8


    internal class ClassConstraint<T> where T : class
    {
        public ClassConstraint(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

    }



    #endregion

    #region Q9

    internal class newConstraint<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }

    }


    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person()
        {
            Name = "Hamada";
            Age = 24;
        }

        public override string ToString() => $"Name: {Name}, Age: {Age}";

    }


    #endregion

    #region Q10

    internal class Comaparer
    {
        public static T FindMax<T>(T[] items) where T : IComparable<T>
        {
            T max = items[0];
            foreach (T item in items)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
            return max;
        }
        public static T FindMin<T>(T[] items) where T : IComparable<T>
        {
            T min = items[0];
            foreach (T item in items)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }
            return min;
        }
    }

    class Student : IComparable<Student>
    {
        public int Grade { get; set; }

        public int CompareTo(Student other)
        {
            return Grade.CompareTo(other.Grade);
        }
    }

    class Student2
    {
        public int Grade { get; set; }

        public int CompareTo(Student2 other)
        {
            return Grade.CompareTo(other.Grade);
        }
    }


    #endregion

    #region Q11






    #endregion

    #region Q12






    #endregion



    #endregion






}
