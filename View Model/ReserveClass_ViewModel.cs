using Cowrk_Space_Mangment_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.View_Model
{
    public class ReserveClass_ViewModel
    {
        public string Client_Name { get; set; }
        public string phone { get; set; }
        public DateTime Date_Reserve { get; set; }

        [DataType(DataType.Time)]
        public DateTime Start_Time { get; set; }

        public int ExpextedHours { get; set; }
      
        public string type_Room { get; set; }

        public int ClientID { get; set; }
        public List<Client> clients { get; set; }

    }
    }

