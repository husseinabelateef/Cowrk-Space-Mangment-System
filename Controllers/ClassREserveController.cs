using Cowrk_Space_Mangment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.View_Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Controllers
{

    public class ClassREserveController : Controller
    {
        IRoomRepository roomRepository;
        IReserveClassRepository reserveClassRepository;
        IReservationRepository reservationRepository;
        IClientRepository clientRepository;
        ICartRepository cartRepository;
      
        private UserManager<ApplicationUser> userManager;


        Context context = new Context();


        public ClassREserveController(Context con, IRoomRepository room, IReservationRepository res, IReserveClassRepository resclass , IClientRepository client, ICartRepository cart, UserManager<ApplicationUser> user)
        {
            context=con;
            roomRepository = room;
            reserveClassRepository = resclass;
            reservationRepository = res;
            clientRepository = client;
            cartRepository = cart;
            userManager = user;
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User);
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult creat()
        {
           ReserveClass_ViewModel reserveClass_ViewModel = new ReserveClass_ViewModel();
            reserveClass_ViewModel.clients = clientRepository.GetAll();
            return View(reserveClass_ViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> creatSave( ReserveClass_ViewModel reserveClass)
        {
            if (ModelState.IsValid == true)
            {
                Reservation reservation = new Reservation();
                RoomReserve roomReserve = new RoomReserve();
                ClientCart clientCart = new ClientCart();
                Cart cart = new Cart();
                reservation.Client_ID = reserveClass.ClientID;
                clientCart.Cart = cart;
                clientCart.Cart_Id = cart.ID;
                reservation.Start_Time = reserveClass.Start_Time;
                reservation.ExpextedHours = reserveClass.ExpextedHours;
                reservation.Date = reserveClass.Date_Reserve;
                roomReserve.Room = new Room();
                roomReserve.Room.Name = reserveClass.type_Room;
                // var UserModel = await GetCurrentUserAsync();
                // reservation.AppuserID = UserModel.Id;
                clientCart.Reservation_ID = reservation.ID;
                ApplicationUser applicationUser = new ApplicationUser();
                reservation.AppuserID = applicationUser.Id;
                roomReserve.Reservation_Id = reservation.ID;
                reservation.RoomReserve = new List<RoomReserve>();
                reservation.RoomReserve.Add(roomReserve);
                reservation.ClientCart = clientCart;
                cartRepository.Insert(clientCart.Cart);
                roomRepository.Insert(roomReserve.Room);
                
                reservationRepository.Insert(reservation);
                context.Add(clientCart);
                context.SaveChanges();
                reserveClassRepository.Insert(roomReserve);
                return RedirectToAction("Index");
            }     
            return View("creat", reserveClass);
        }


        public IActionResult GetAll_Reservation()
        {
            var res=roomRepository.GetAll();
            return View(res);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

            [HttpPost]
        public IActionResult Delete(RoomReserve roomReserve)
        {
            reserveClassRepository.Delete(roomReserve.Id);       
            return RedirectToAction("Index");

        }
    }
}
