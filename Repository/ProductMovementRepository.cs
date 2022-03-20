using Cowrk_Space_Mangment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ProductMovementRepository: IProductMovementsRepository
    {
        Context context;
        public ProductMovementRepository(Context _context)
        {
            context = _context;
        }
        public List<ProductMovments> GetAll()
        {
            return context.ProductMovments.ToList();
        }

        public ProductMovments GetById(Guid id)
        {
            return context.ProductMovments.FirstOrDefault(ProductMovment => ProductMovment.ProductID == id);
        }

        public int Insert(ProductMovments ProductMovment)
        {
            context.ProductMovments.Add(ProductMovment);
            return context.SaveChanges();
        }

        public int Update(Guid id, ProductMovments ProductMovment)
        {
            ProductMovments oldProductMovment = GetById(id);
            if (oldProductMovment != null)
            {
                oldProductMovment.Amount = ProductMovment.Amount;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(Guid id)
        {
            ProductMovments oldProductMovment = GetById(id);
            context.ProductMovments.Remove(oldProductMovment);
            return context.SaveChanges();
        }
    }
}
