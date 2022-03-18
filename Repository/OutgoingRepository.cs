using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class OutgoingRepository :IOutgoingRepository
    {
        Context context;
        public OutgoingRepository(Context _context)
        {
            context = _context;
        }
        public List<Outgoing> GetAll()
        {
            return context.Outgoing.ToList();
        }

        public Outgoing GetById(int id)
        {
            return context.Outgoing.FirstOrDefault(outgoing => outgoing.ID == id);
        }

        public int Insert(Outgoing outgoing)
        {
            context.Outgoing.Add(outgoing);
            return context.SaveChanges();
        }

        public int Update(int id, Outgoing outgoing)
        {
            Outgoing oldoutgoing = GetById(id);
            if (oldoutgoing != null)
            {
                oldoutgoing.Name = outgoing.Name;
                oldoutgoing.Price = outgoing.Price;
                oldoutgoing.Date = outgoing.Date;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Outgoing oldoutgoing = GetById(id);
            context.Outgoing.Remove(oldoutgoing);
            return context.SaveChanges();
        }
   
    }
}
