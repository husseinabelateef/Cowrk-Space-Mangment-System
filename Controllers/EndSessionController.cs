﻿using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using Cowrk_Space_Mangment_System.View_Model;
using Cowrk_Space_Mangment_System.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Cowrk_Space_Mangment_System.Controllers
{
    [Authorize]
    public class EndSessionController : Controller
    {
        IIncommingRepository incommingRepository;
        ICartRepository cartRepository;
        IReservationRepository reservationRepository;
        IClientRepository clientRepository;
        IChairRepository chairRepository;

        private UserManager<ApplicationUser> userManager;

        public EndSessionController(UserManager<ApplicationUser> user, IIncommingRepository incomming, ICartRepository cart, IReservationRepository reserv , IClientRepository client, IChairRepository chair)
        {
            userManager = user;
            incommingRepository = incomming;
            cartRepository = cart;
            reservationRepository = reserv;
            clientRepository = client;
            chairRepository = chair;
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User);
        public IActionResult getData()
        {

            return View(new EndSessionViewModel());

        }
        [HttpPost]
        public async Task<IActionResult> CheckoutAsync(EndSessionViewModel endSess )
        {

            Client client = clientRepository.GetById(endSess.Client_ID);
            Reservation reservation = client.Reservations.Last();
            if(endSess.ReservationType == "Room")
            {
                reservation.RoomReserve.Last().End_Time = DateTime.Now;
  
                reservation.Hours_Price = (reservation.RoomReserve.Last().End_Time - reservation.Start_Time).Minutes * 5.0 / 60.0;
                endSess.TotalPriceReserv = reservation.TotalPrice;
                endSess.TotalHoure = (reservation.RoomReserve.Last().End_Time - reservation.Start_Time).Hours;

            }
            else
            {
                reservation.ChairReserves.End_Time = DateTime.Now;
                reservation.Hours_Price = (reservation.ChairReserves.End_Time - reservation.Start_Time).Minutes * 5.0/60.0;
                endSess.TotalPriceReserv = reservation.TotalPrice;
                endSess.TotalHoure = (reservation.ChairReserves.End_Time - reservation.Start_Time).Hours;
                Chair chair = chairRepository.GetById(reservation.ChairReserves.Chair_Id);
                chair.Availability = true;
                chairRepository.Update(chair.Id, chair);



            }
           endSess.TotalPriceCatring = reservation.Cart.TotalPrice;
            endSess.TotalForAll = endSess.TotalPriceCatring + endSess.TotalPriceReserv;
            reservation.TotalPrice = endSess.TotalForAll;
            reservationRepository.Update(reservation.ID,reservation);
            var UserModel = await GetCurrentUserAsync();
            
            Incomming incomming = new Incomming();
            
            incomming.AppuserID = UserModel.Id;
            incomming.ShiftCloseReservationIncome = endSess.TotalPriceReserv;
            incomming.ShiftCloseCateringIncome = endSess.TotalPriceCatring;
            incomming.Date= DateTime.Now;

            incommingRepository.Insert(incomming);
            return View(endSess);
        }

    }
}
