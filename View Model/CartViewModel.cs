using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.View_Model
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string ClientName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
