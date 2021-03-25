using api2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class IProductRepos : ProductRepos
    {
        private readonly AppDbContext db;
        public IProductRepos(AppDbContext _db)
        {
            db = _db;
        }

        public void create(product p)
        {
            db.products.Add(p);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.products.Remove(db.products.Find(id));
            db.SaveChanges();
        }

        public product GetProduct(int id)
        {
            return db.products.Find(id);
        }

        public IEnumerable<product> GetProducts()
        {
            return db.products.ToList();
        }

        public IEnumerable<product> GetProductsByName(string name)
        {
            return db.products.Where(x => x.Name == name).ToList();
        }

        public void update(product p)
        {
            db.products.Update(p);
            db.SaveChanges();
        }
    }
}
