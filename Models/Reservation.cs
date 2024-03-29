﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [Display(Name ="Start Time")]
        [Required(ErrorMessage ="Enter Start Time For Session")]
        [DataType(DataType.Time)]
        public DateTime Start_Time { get; set; }

        //number Of hours want to Reserve
        [Display(Name = "Expexted Hours")]
        public int ExpextedHours { get; set; }
        [Display(Name = "Receptionst Id")]
        [ForeignKey("Applicationuser")]
        public string AppuserID { get; set; }
        [Display(Name = "Client Id")]
        [ForeignKey("Client")]
        public int Client_ID { get; set; }
        [Display(Name = "ClientCart Id")]
        [ForeignKey("Cart")]
        public int Cart_ID { get; set; }
        // DD/MM/YY
        [Display(Name = "Date of Session")]
        [Required(ErrorMessage = "Enter Date of Session")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Display(Name ="Price For Your Session")]
        public double Hours_Price { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
        public virtual Client Client { get; set; }
        public virtual Cart Cart { get; set; }
        public ICollection<RoomReserve> RoomReserve { get; set; }
        public virtual ChairReserve ChairReserves { get; set; }
        //public virtual Receptionist Receptionist  { get; set; }
        public virtual ApplicationUser Applicationuser { get; set; } 
    }
}
