using Bulky.DataAccess.Data;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db; 
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(x=>x.Id == obj.Id);
            if (objFromDb != null) 
            { 
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Title = obj.Title;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                
                if( obj.ImageUrl != null ) 
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
