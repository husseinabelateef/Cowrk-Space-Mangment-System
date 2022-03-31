using System;
using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context context;
        public ProductRepository(Context context)
        {
            this.context = context;
        }
        public int Delete(Guid id)
        {
            context.Product.Remove(GetById(id));
            return context.SaveChanges();
        }

        public List<Product> ExpiredProduct()
        {
            return context.Product.Where(d => d.ExpireDate < DateTime.Now).ToList();
        }

        public List<Product> GetAll()
        {
            return context.Product.ToList();
        }

        public Product GetById(Guid id)
        {
            return context.Product.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Product item)
        {
            context.Product.Add(item);
            return context.SaveChanges();
        }

        public int Update(Guid id, Product item)
        {
            Product p = GetById(id);
            if (p != null)
            {
                p.Name = item.Name;
                p.BarCode = item.BarCode;
                p.ActualAmount = item.ActualAmount;
                p.ActualPrice = item.ActualPrice;
                p.SellingPrice = item.SellingPrice;
                context.Entry(p).State = EntityState.Modified;
                context.Product.Update(p);
                //context.Update(p);
            }
            return context.SaveChanges();
        }
    }
}
