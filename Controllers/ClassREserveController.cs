using Cowrk_Space_Mangment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.View_Model;


namespace Cowrk_Space_Mangment_System.Controllers
{

    public class ClassREserveController : Controller
    {
        IRoomRepository roomRepository;
        IReserveClassRepository reserveClassRepository;
        IReservationRepository reservationRepository;

        public ClassREserveController(IRoomRepository room, IReservationRepository res, IReserveClassRepository resclass)
        {
            roomRepository = room;
            reserveClassRepository = resclass;
            reservationRepository = res;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult creat()
        {
           ReserveClass_ViewModel reserveClass_ViewModel = new ReserveClass_ViewModel();
            return View();

        }
        [HttpPost]
        public IActionResult creatSave( ReserveClass_ViewModel reserveClass)
        {
            if (ModelState.IsValid == true)
            {
                Reservation reservation = new Reservation();
                RoomReserve roomReserve = new RoomReserve();
                reservation.Start_Time = reserveClass.Start_Time;
                reservation.ExpextedHours = reserveClass.ExpextedHours;
                reservation.Date = reserveClass.Date_Reserve;
                roomReserve.Room.Name = reserveClass.type_Room;
                reservationRepository.Insert(reservation);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
           // return View("creat", reserveClass);
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
