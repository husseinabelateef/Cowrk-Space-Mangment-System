using Cowrk_Space_Mangment_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.View_Model
{
    public class ReservationViewModel
    {
        public DateTime Date_Reserve { get; set; }

        [DataType(DataType.Time)]
        public DateTime Start_Time { get; set; }
        public Reservation Reservation { get; set; }

        public int Client_ID { get; set; }
        public int NO_Available_Chair { get; set; }

        public int ExpextedHours { get; set; }
        [DataType(DataType.DateTime)]
        public string type_Room { get; set; }

        public List<Chair> chairs { get; set; }
        public List<Client> clients { get; set; }
      }
    }

