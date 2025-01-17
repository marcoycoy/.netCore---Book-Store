﻿using Refresher.DataAccess.Data;
using Refresher.DataAccess.Repository.IRepository;
using Refresher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresher.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        public void update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50  = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
