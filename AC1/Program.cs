using AC1.Generic_Class;
using AC1.Generic_Constraints;
using AC1.Generic_Interface;

namespace AC1
{
    internal class Program
    {

        #region Q11 - Base Class Constraint

        // A base class constraint requires T to inherit from a specific class.

        class Animal
        {
            public void Eat()
            {
                Console.WriteLine("Eating...");
            }
        }

        class Dog : Animal
        {
        }

        class AnimalHelper<T> where T : Animal
        {
            public void MakeEat(T animal)
            {
                animal.Eat();
            }
        }

        #endregion

        #region Q12 - Multiple Constraints

        // By using commas.

        class Student : IComparable<Student>
        {
            public int Grade { get; set; }

            public int CompareTo(Student other)
            {
                return Grade.CompareTo(other.Grade);
            }
        }

        class StudentHelper<T>
            where T : class, IComparable<T>, new()
        {
            public T Create()
            {
                return new T();
            }
        }
        #endregion

        #region Q13 - default Keyword in Generics

        // default(T) returns the default value of the type T.

        public static T GetDefault<T>()
        {
            return default(T);
        }

        #endregion

        #region Q14 - SafeList<T>

        // SafeList returns default(T) when the index is invalid.

        class SafeList<T>
        {
            private T[] _items;

            public SafeList(int size)
            {
                _items = new T[size];
            }

            public void Add(int index, T item)
            {
                if (index >= 0 && index < _items.Length)
                {
                    _items[index] = item;
                }
            }

            public T Get(int index)
            {
                if (index >= 0 && index < _items.Length)
                {
                    return _items[index];
                }

                return default(T);
            }
        }

        #endregion

        #region Q15 - Covariance and out

        // Covariance allows you to use a more derived type where a less derived type is expected.

        // The 'out' keyword means the generic type is mainly used as an OUTPUT/return type.


        #endregion

        #region Q16 - Contravariance and in

        // Contravariance allows you to use a less derived type where a more derived type is expected.

        // The 'in' keyword means the generic type is used as an INPUT/parameter.


        #endregion

        #region Q17 - Diff

        /*
         
         Aspect	Covariance (out)	Contravariance (in)
         Direction	Derived → Base	Base → Derived
         T Position	Output only (return)	Input only (parameter)
         Example	IEnumerable<out T>	Action<in T>
         Think of as	Producer of T	Consumer of T
         
         
         
         
         */

        #endregion

        #region Q18 - Static Members in Generic Types

        // Each closed generic type has its own copy of static fields. Counter<int> and Counter<string> have separate static data.

        class Counter<T>
        {
            public static int Count = 0;

            public Counter()
            {
                Count++;
            }
        }

        #endregion

        #region Q19 - Inheriting from a Generic Class

        // Generic classes can inherit from other generic or non-generic classes.

        class Repository<T>
        {
            public void Add(T item)
            {
                Console.WriteLine($"Added: {item}");
            }
        }

        class StudentRepository : Repository<Student>
        {
        }

        #endregion

        #region Q20 - Generic Cache<TKey, TValue>

        class Cache<TKey, TValue>
        {
            private class CacheItem
            {
                public TValue Value { get; set; }
                public DateTime Expiration { get; set; }
            }

            private Dictionary<TKey, CacheItem> _items = new Dictionary<TKey, CacheItem>();


            public void Add(TKey key, TValue value, TimeSpan expiration)
            {
                _items[key] = new CacheItem
                {
                    Value = value,
                    Expiration = DateTime.Now.Add(expiration)
                };
            }

            public TValue Get(TKey key)
            {
                if (!_items.ContainsKey(key))
                {
                    return default(TValue);
                }

                CacheItem item = _items[key];

                if (DateTime.Now >= item.Expiration)
                {
                    _items.Remove(key);
                    return default(TValue);
                }

                return item.Value;
            }


            public void Remove(TKey key)
            {
                _items.Remove(key);
            }


            public bool Contains(TKey key)
            {
                if (!_items.ContainsKey(key))
                {
                    return false;
                }

                CacheItem item = _items[key];

                if (DateTime.Now >= item.Expiration)
                {
                    _items.Remove(key);
                    return false;
                }

                return true;
            }
        }


        #endregion
        static void Main(string[] args)
        {
            #region Q2


            Q2<int> Container1 = new Q2<int>(5);

            Container1.Add(5);
            Container1.Add(14);
            Container1.Add(24);
            Container1.Add(57);
            Console.WriteLine(Container1.Get(0));
            Console.WriteLine(Container1.Get(1));
            Console.WriteLine(Container1.Get(2));
            Console.WriteLine(Container1.Get(3));
            #endregion

            #region Q3

            Q3<string, int> KeyValue = new Q3<string, int>("Omar", 23);

            Console.WriteLine(KeyValue.ToString());


            #endregion

            #region Q4

            // A generic method declares its own type parameter(s). It can exist in both generic and non-generic classes.
            int a = 12; int b = 23;

            Q4 q4 = new Q4();

            Console.WriteLine(q4.Max(a, b));

            q4.Swap(ref a, ref b);

            Console.WriteLine($"{b}:{a}");
            #endregion

            #region Generic Interface


            IRepository<Product> Repo1 = new ProductRepo();

            Repo1.Add(new Product(1, "Laptop", 900));
            Repo1.Add(new Product(2, "Mouse", 30));
            Repo1.Add(new Product(3, "Keyboard", 200));

            Console.WriteLine("All Products");
            foreach (var item in Repo1.GetAll())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Get By Id:  {Repo1.GetById(2)}");

            #endregion

            #region Generic Constraints


            #region Q7

            StructConstraint<int> structcon1 = new StructConstraint<int>(5);

            //StructConstraint<string> structcon2 = new StructConstraint<string>("5");

            #endregion

            #region Q8

            ClassConstraint<string> classCon2 = new ClassConstraint<string>("5");

            //ClassConstraint<int> classCon1 = new ClassConstraint<int>(5);



            #endregion

            #region Q9

            newConstraint<Person> Persons = new newConstraint<Person>();

            Person P1 = Persons.Create();

            P1.Name = "Ahmed";
            P1.Age = 22;

            Console.WriteLine($"Created: {P1}");



            #endregion

            #region Q10


            Student[] students = {

            new Student { Grade = 80 },
            new Student { Grade = 95 },
            new Student { Grade = 70 }

            };


            Student best = Comaparer.FindMax(students);

            Console.WriteLine(best.Grade);

            //Student2[] students2 = {
            //new Student2 { Grade = 80 },
            //new Student2 { Grade = 95 },
            //new Student2 { Grade = 70 }

            //};


            //Student best2 = Comaparer.FindMax(students2);

            //Console.WriteLine(best2.Grade);
            #endregion


            #endregion


            #region Q20





        Example:

            Cache<string, string> cache = new Cache<string, string>();

            cache.Add(
                "username",
                "Ahmed",
                TimeSpan.FromSeconds(10)
            );

            Console.WriteLine(cache.Get("username"));

            Console.WriteLine(cache.Contains("username"));

            cache.Remove("username");

            Console.WriteLine(cache.Contains("username"));

            Console.WriteLine(cache.Get("username"));

            #endregion

        }
    }
}