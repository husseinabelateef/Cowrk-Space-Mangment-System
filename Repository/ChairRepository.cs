using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ChairRepository : IChairRepository
    {
        Context context;
        public ChairRepository(Context context)
        {
            this.context = context;
        }
        public List<Chair> GetAll()
        {
            return context.Chair.Include(r=>r.Room).ToList();
        }
        public Chair GetById(int id)
        {
            return context.Chair.FirstOrDefault(ch => ch.Id == id);
        }
        public int Insert(Chair chair)
        {
            context.Chair.Add(chair);
            return context.SaveChanges();
        }

        public int Update(int id, Chair chair)
        {

            Chair Old_chair = GetById(id);
            if (Old_chair != null)
            {
                Old_chair.Id = chair.Id;
                Old_chair.Availability = chair.Availability;
                Old_chair.Room_ID = chair.Room_ID;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Chair chair = GetById(id);
            context.Chair.Remove(chair);
            return context.SaveChanges();
        }
    }
}
