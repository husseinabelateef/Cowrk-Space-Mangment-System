using System;
using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        public Context Context;
        public DrinkRepository(Context context)
        {
            this.Context = context;
        }
        public int Delete(int id)
        {
            Context.Drink.Remove(GetById(id));
            return Context.SaveChanges();
        }

        public List<Drink> GetAll()
        {
            return Context.Drink.ToList();
        }

        public Drink GetById(int id)
        {
            return Context.Drink.FirstOrDefault(x => x.ID == id);
        }

        public int Insert(Drink item)
        {
            Context.Drink.Add(item);
            return Context.SaveChanges();
        }
        // Drink Consist of what ? 
        public List<RawProduct> ProductMaterial(Guid ProductID)
        {
            return Context.Drink.Where(d=>d.ProductId == ProductID).
                Include(d => d.RawProduct).Select(d=>d.RawProduct).ToList();
            
        }

        public List<Product> RawAvailableFor(int RawProductId)
        {
            return Context.Drink.Where(d => d.RawProID == RawProductId).
                Include(d => d.Product).Select(d => d.Product).ToList();
        }

        public int Update(int id, Drink item)
        {
            Drink drink = Context.Drink.FirstOrDefault(d => d.ID == id);
            if (drink != null)
            {
                drink.RawProID = item.RawProID;
                drink.ProductId = item.ProductId;
                Context.Drink.Update(drink);

            }
            return Context.SaveChanges();


        }
    }
}
