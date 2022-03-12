using System;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Deal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PromoCode { get; set; }
        public string ClassOffer { get; set; }
        public string IndividualOrSharedOffer { get; set; }
        public string CoffeeMachineOffer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
