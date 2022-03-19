using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ChairReserveRepository : IChairReserveRepository
    {
        Context context;
        public ChairReserveRepository(Context context)
        {
            this.context = context;
        }
        public List<ChairReserve> GetAll()
        {
            return context.chairReserve.ToList();
        }

        public ChairReserve GetById(int id)
        {
            return context.chairReserve.FirstOrDefault(CR => CR.Id == id);
        }

        public int Insert(ChairReserve chairreserve)
        {
            context.chairReserve.Add(chairreserve);
            return context.SaveChanges();
        }

        public int Update(int id, ChairReserve chairreserve)
        {
            ChairReserve Old_CR = GetById(id);
            if (Old_CR != null)
            {
                Old_CR.Id = chairreserve.Id;
                Old_CR.End_Time = chairreserve.End_Time;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            ChairReserve Old_CR = GetById(id);
            context.chairReserve.Remove(Old_CR);
            return context.SaveChanges();
        }

    }
}
