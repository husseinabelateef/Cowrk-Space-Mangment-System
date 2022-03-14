using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class AssignPackage
    {
        public int ID { get; set; }
        [ForeignKey("package")]
        public int PackageID { get; set; }
        [ForeignKey("client")]
        public int ClientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Package package { get; set; }
        public virtual Client client { get; set; }

    }
}
