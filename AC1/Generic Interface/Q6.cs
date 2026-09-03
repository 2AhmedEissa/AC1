using System;
using System.Collections.Generic;
using System.Text;

namespace AC1.Generic_Class
{
    public interface IRepository<T> where T : class
    {
        //Generic interfaces define contracts with type parameters. Classes implementing them specify the actual types.

        void Add(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();

        void Delete(int id);


    }
}
