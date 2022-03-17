using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        Context context;
        public ReservationRepository(Context _context)
        {
            context = _context;
        }
        public List<Reservation> GetAll()
        {
            return context.Reservation.ToList();
        }

        public Reservation GetById(int id)
        {
            return context.Reservation.FirstOrDefault(Reservation => Reservation.ID == id);
        }

        public int Insert(Reservation Reservation)
        {
            context.Reservation.Add(Reservation);
            return context.SaveChanges();
        }

        public int Update(int id, Reservation Reservation)
        {
            Reservation oldReservation = GetById(id);
            if (oldReservation != null)
            {
                oldReservation.Start_Time = Reservation.Start_Time;
                oldReservation.ExpextedHours = Reservation.ExpextedHours;
                oldReservation.Date = Reservation.Date;
                oldReservation.ClientCart_ID = Reservation.ClientCart_ID;
                oldReservation.Client_ID = Reservation.Client_ID;
                oldReservation.Receptionst_Id = Reservation.Receptionst_Id;
                oldReservation.Hours_Price = Reservation.Hours_Price;
                oldReservation.TotalPrice = Reservation.TotalPrice;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Reservation oldReservation = GetById(id);
            context.Reservation.Remove(oldReservation);
            return context.SaveChanges();
        }
    }
}
