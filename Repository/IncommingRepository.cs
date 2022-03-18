using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class IncommingRepository : IIncommingRepository
    {
        Context context;
        public IncommingRepository(Context context)
        {
            this.context = context;
        }
        public List<Incomming> GetAll()
        {
            return context.Incomming.ToList();
        }

        public Incomming GetById(int id)
        {
            return context.Incomming.FirstOrDefault(Income => Income.Id == id);
        }

        public int Insert(Incomming incomming)
        {
            context.Incomming.Add(incomming);
            return context.SaveChanges();
        }

        public int Update(int id, Incomming Income)
        {

            Incomming Old_Income = GetById(id);
            if (Old_Income != null)
            {
                Old_Income.Id = Income.Id;
                Old_Income.Date = Income.Date;
                Old_Income.ShiftCloseReservationIncome = Income.ShiftCloseReservationIncome;
                Old_Income.ShiftCloseCateringIncome = Income.ShiftCloseCateringIncome;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Incomming Old_Income = GetById(id);
            context.Incomming.Remove(Old_Income);
            return context.SaveChanges();
        }
    }
}
