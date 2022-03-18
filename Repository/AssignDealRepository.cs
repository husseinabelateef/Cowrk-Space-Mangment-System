using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class AssignDealRepository :IAssignDeal_Repository
    {
        Context context;
        public AssignDealRepository(Context _context)
        {
            context = _context;
        }
        public List<AssignDeals> GetAll()
        {
            return context.AssignDeals.ToList();
        }

        public AssignDeals GetById(int id)
        {
            return context.AssignDeals.FirstOrDefault(deal => deal.ID == id);
        }

        public int Insert(AssignDeals assignDeal)
        {
            context.AssignDeals.Add(assignDeal);
            return context.SaveChanges();
        }

        public int Update(int id, AssignDeals assignDeal)
        {
            AssignDeals oldDeal = GetById(id);
            if (oldDeal != null)
            {
                oldDeal.DealID = assignDeal.DealID;
                oldDeal.ClientID= assignDeal.ClientID;
                oldDeal.StartDate = assignDeal.StartDate;
                oldDeal.EndDate = assignDeal.EndDate;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            AssignDeals oldDeal = GetById(id);
            context.AssignDeals.Remove(oldDeal);
            return context.SaveChanges();
        }
    }
}
