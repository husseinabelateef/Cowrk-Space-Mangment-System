namespace Cowrk_Space_Mangment_System.Models
{
    public class Package
    {
        public int ID { get; set; }
        public string Name { get; set; } // monthly Packge Or so on 
        // Discount for Coffee machine 
        public double Offer { get; set; }
        //total hours for individual Room
        public int NumberOfHours { get; set; }
        //total Days available for this packge 
        public int NumberOfDays { get; set; }
        public float Price { get; set; }

    }
}
