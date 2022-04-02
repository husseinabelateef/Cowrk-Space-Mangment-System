using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using System.Collections.Generic;
using Cowrk_Space_Mangment_System.View_Model;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Controllers
{

    public class ReservationController : Controller
    {
        IReservationRepository reservationRepository;
        IClientRepository clientRepository;
        ICartRepository cartRepository;
        IChairRepository chairRepository;
        IRoomRepository roomRepository;
        IChairReserveRepository chairReserveRepository;
        IReserveClassRepository reserveClassRepository;
        Context context;
        private UserManager<ApplicationUser> userManager;
        private async Task<ApplicationUser> GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User);

        public ReservationController(UserManager<ApplicationUser> _userManager
            , IReservationRepository reservationRepo
            , IClientRepository clientRepo
            , ICartRepository cartRepo
            , IChairRepository chairRepo
            , IRoomRepository roomRepo
            , IReserveClassRepository _reserveClassRepository
            , IChairReserveRepository _chairreserveRepository
            , Context _context)
        {
            userManager = _userManager;
            reservationRepository = reservationRepo;
            clientRepository = clientRepo;
            cartRepository = cartRepo;
            chairRepository = chairRepo;
            roomRepository = roomRepo;
            reserveClassRepository = _reserveClassRepository;
            chairReserveRepository = _chairreserveRepository;

            context = _context;
        }

        public IActionResult GetAllClients()
        {

            List<Client> clients = clientRepository.GetAll();
            return View(clients);
        }
        public ActionResult GetAllReservations()
        {
            List<Reservation> Reservations = reservationRepository.GetAll();
            return View(Reservations);
        }
        public ActionResult Details(int id)
        {
            Reservation reservation = reservationRepository.GetById(id);
            return View(reservation);
        }
        //Reservation/NewReservation

        public IActionResult GetAvailableChairs(string RoomType)
        {
            Room room = roomRepository.GetByName(RoomType);
            List<Chair> chairs = chairRepository.GetAll();
            chairs = chairs.Where(ch => ch.Availability == true && ch.Room_ID == room.ID).ToList();

            return Json(chairs.Count());
        }

        public IActionResult NewCart()
        {
            return View(new Cart());
        }
        public IActionResult SaveNewCart(Cart cart)
        {
            cartRepository.Insert(cart);
            return View("NewReservation", cart);
        }
        public IActionResult NewReservation()
        {

            ReservationViewModel Reservation = new ReservationViewModel();
            Reservation.clients = clientRepository.GetAll();
            Reservation.chairs = new List<Chair>();

            //Reservation.Reservation.Client_ID = 0;

            //ClientCart clientCart = new ClientCart();
            //clientCart.Cart = cart;
            //context.clientCart.Add(clientCart);
            //context.SaveChanges();


            //   reservationRepository.Insert(Reservation.Reservation);


            return View(Reservation);
        }

        [HttpPost]
        public ActionResult SaveNewReservation(ReservationViewModel reservation)
        {
            if (ModelState.IsValid == true)
            {

                // Reservation res = new Reservation();

                Cart cart = new Cart();
                cartRepository.Insert(cart);
                reservation.Reservation = new Reservation();
                reservation.Reservation.Cart = cart;



                reservation.Reservation.Date = reservation.Date_Reserve;


                reservation.Reservation.Start_Time = reservation.Start_Time;
                reservation.Reservation.ExpextedHours = reservation.ExpextedHours;
                //reservation.Reservation.Hours_Price = 10;
                reservation.Reservation.Client_ID = reservation.Client_ID;

                //res.ClientCart_ID = reservation.Clientcart.ID;
                //var UserModel = await GetCurrentUserAsync();
                //ApplicationUser user = new ApplicationUser();
                //res.AppuserID = user.Id;
                if (reservation.type_Room == "Individual" || reservation.type_Room == "Shared")
                {

                    reservation.Reservation.ChairReserves = new ChairReserve();
                    reservation.Reservation.Cart.IsClient = true;
                    reservation.Reservation.Cart.Date = reservation.Date_Reserve;

                    List<Chair> chairs = chairRepository.GetAll();
                    Room room = roomRepository.GetByName(reservation.type_Room);
                    reservation.chairs = chairs.Where(ch => ch.Availability == true 
                    && ch.Room_ID == room.ID).ToList();
                    if (reservation.chairs.Count() > 0)
                    {
                        foreach (var item in reservation.chairs)
                        {
                            if (item.Availability == true)
                            {
                                reservation.Reservation.ChairReserves.Chair_Id = item.Id;
                                item.Availability = false;
                                break;
                            }
                        }
                        reservationRepository.Insert(reservation.Reservation);
                       // chairReserveRepository.Insert(reservation.Reservation.ChairReserves);
                        ClientCart clientCart = new ClientCart();
                        clientCart.Reservation_ID = reservation.Reservation.ID;
                        clientCart.Cart_Id = reservation.Reservation.Cart_ID;
                        context.clientCart.Add(clientCart);
                        context.SaveChanges();
                        return RedirectToAction("GetAllReservations");



                    }


                }
                else
                {
                    RoomReserve roomreserve = new RoomReserve();
                    Room room = roomRepository.GetByName(reservation.type_Room);
                    roomreserve.Rooom_Id = room.ID;
                    roomreserve.Reservation_Id = reservation.Reservation.ID;
                    reservation.Reservation.RoomReserve = new List<RoomReserve>();
                    reservation.Reservation.RoomReserve.Add(roomreserve);
                    reservationRepository.Insert(reservation.Reservation);

                    ClientCart clientCart = new ClientCart();
                    clientCart.Reservation_ID = reservation.Reservation.ID;
                    clientCart.Cart_Id = reservation.Reservation.Cart_ID;
                    context.clientCart.Add(clientCart);
                    context.SaveChanges();




                    return RedirectToAction("GetAllReservations");
                }



            }
            return View("NewReseration", reservation.Reservation);

        }


    }
}



