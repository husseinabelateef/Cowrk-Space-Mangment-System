using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class RawProductMovmentsRepository : IRawProductMovmentRepository
    {
        Context context;
        public RawProductMovmentsRepository(Context _context)
        {
            context = _context;
        }
        public List<RawProductMovments> GetAll()
        {
            return context.RawProductMovments.ToList();
        }

        public RawProductMovments GetById(int id)
        {
            return context.RawProductMovments.FirstOrDefault(RawProductMovments => RawProductMovments.Raw_ProductID == id);
        }

        public int Insert(RawProductMovments RawProductMovments)
        {
            context.RawProductMovments.Add(RawProductMovments);
            return context.SaveChanges();
        }

        public int Update(int id, RawProductMovments RawProductMovments)
        {
            RawProductMovments oldRawProductMovments = GetById(id);
            if (oldRawProductMovments != null)
            {
                oldRawProductMovments.Amount = RawProductMovments.Amount;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            RawProductMovments oldRawProductMovments = GetById(id);
            context.RawProductMovments.Remove(oldRawProductMovments);
            return context.SaveChanges();
        }
    }
}
