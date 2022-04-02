using System;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Deal
    {
        public int ID { get; set; }
        public string Name { get; set; } //student Activity 
        public string PromoCode { get; set; } // 
        public double ClassOffer { get; set; }
        public double IndividualOrSharedOffer { get; set; }
        public double CoffeeMachineOffer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
