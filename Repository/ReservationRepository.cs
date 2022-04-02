using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        Context context;
        
        public ReservationRepository(Context _context )
        {
            context = _context;
        }
        public List<Reservation> GetAll()
        {
            return context.Reservation.ToList();
        }

        public Reservation GetById(int id)
        {
            return context.Reservation.Include(x=>x.ChairReserves).Include(x=>x.RoomReserve).
                Include(c=>c.Client).Include(c=>c.Cart).FirstOrDefault(Reservation => Reservation.ID == id);
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
                oldReservation.Client_ID = Reservation.Client_ID;
                oldReservation.AppuserID = Reservation.AppuserID;
                oldReservation.Hours_Price = Reservation.Hours_Price;
                oldReservation.TotalPrice = Reservation.TotalPrice;
                context.Entry(oldReservation).State = EntityState.Modified;
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
        public int GetReservationIdForUser(int ClientId)
        {
          return  context.Reservation.Where(x => x.Client_ID == ClientId).Select(x => x.ID).Last();
        }

        public Cart GetLastCartForUser(int ClientId)
        {
           Reservation reservation = context.Reservation.OrderBy(x=>x.Date).
           Include(x=>x.Cart).LastOrDefault(x => x.Client_ID == ClientId);
           return reservation == null ? null : context.Cart.FirstOrDefault(x => x.ID == reservation.Cart.ID);
        }

        public Reservation where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public Reservation getCartReservation(int CartId)
        {
            return context.Reservation.Include(x=>x.Client).FirstOrDefault(x => x.Cart_ID == CartId);
        }
    }
}
