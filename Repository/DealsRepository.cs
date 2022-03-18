using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;
namespace Cowrk_Space_Mangment_System.Repository
{
    public class DealsRepository : IDealsRepository
    {
        Context context;
        public DealsRepository(Context _context)
        {
            context = _context;
        }

        public List<Deal> GetAll()
        {
            return context.Deal.ToList();
        }

        public Deal GetById(int id)
        {
            return context.Deal.FirstOrDefault(Deal => Deal.ID == id);
        }

        public int Insert(Deal deal)
        {
            context.Deal.Add(deal);
            return context.SaveChanges();
        }

        public int Update(int id, Deal deal)
        {
            Deal oldDeal = GetById(id);
            if (oldDeal != null)
            {

                oldDeal.Name = deal.Name;
                oldDeal.PromoCode=deal.PromoCode;
                oldDeal.ClassOffer= deal.ClassOffer;
                oldDeal.CoffeeMachineOffer= deal.CoffeeMachineOffer;
                oldDeal.IndividualOrSharedOffer = deal.IndividualOrSharedOffer;
                oldDeal.StartDate=deal.StartDate;
                oldDeal.EndDate=deal.EndDate;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Deal oldDeal = GetById(id);
            context.Deal.Remove(oldDeal);
            return context.SaveChanges();
        }
    }
}
