using AC1.Generic_Class;
using AC1.Generic_Interface;

namespace AC1
{
    internal class Program
    {


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
            Repo1.Delete(2);

            #endregion

        }
    }
}