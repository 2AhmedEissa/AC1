using AC1.Generic_Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC1.Generic_Interface
{
    internal class ProductRepo : IRepository<Product>
    {

        private List<Product> _products = new List<Product>();
        public void Add(Product item)
        => _products.Add(item);

        public void Delete(int id)
        => _products.RemoveAll(P => P.Id == id);

        public IEnumerable<Product> GetAll()
        => _products;

        public Product GetById(int id)
        => _products.Find(P => P.Id == id);
    }
}
