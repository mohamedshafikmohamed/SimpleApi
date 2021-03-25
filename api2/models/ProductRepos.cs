using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
  public  interface ProductRepos
    {
       public IEnumerable<product> GetProducts();
        public IEnumerable<product> GetProductsByName(string name);
       public  product GetProduct(int id); 
        public  void Delete(int id);
        public  void create(product p);
        public  void update(product p);
    }
}
