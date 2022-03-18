using System;
using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class RawProductRepository : IRawProductRepository
    {
        readonly private Context context;
        public RawProductRepository(Context context)
        {
               this.context = context;  
        }
        public int Delete(int id)
        {
            context.RawProduct.Remove(GetById(id));
            return context.SaveChanges();
        }

        public List<RawProduct> ExpiredRaw()
        {
            return context.RawProduct.Where(d => d.ExpireDate > DateTime.Now).ToList();
        }

        public List<RawProduct> GetAll()
        {
            return context.RawProduct.ToList();
        }

        public RawProduct GetById(int id)
        {
            return context.RawProduct.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(RawProduct item)
        {
            context.RawProduct.Add(item);
            return context.SaveChanges();
        }

        public int Update(int id, RawProduct item)
        {
            RawProduct r = GetById(id);
            if (r != null)
            {
                r.Quantity = item.Quantity;
                r.NOC = item.NOC;
                r.RefrenceCupWeight = item.RefrenceCupWeight;
                r.ExpireDate = item.ExpireDate;
                r.Name = item.Name;
                context.RawProduct.Update(r);
            }
            return context.SaveChanges();
        }
    }
}
