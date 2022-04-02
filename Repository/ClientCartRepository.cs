using System;
using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ClientCartRepository : IClientCart
    {
        Context context;
        private IReservationRepository reservation;
        public ClientCartRepository(Context context , IReservationRepository reservation)
        {
            this.context = context;
            this.reservation = reservation;
        }

        public string clientName(int CartId)
        {
            try
            {
                Reservation res = reservation.getCartReservation(CartId);
                if (res != null)
                {
                    return res.Client.Name;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public int Delete(int id)
        {
            context.clientCart.Remove(GetById(id));
            return context.SaveChanges();
        }

        public List<ClientCart> GetAll()
        {
            return context.clientCart.Include(x=>x.Cart).ToList();
        }

        public ClientCart GetById(int id)
        {
            return context.clientCart.Include(x=>x.Cart).FirstOrDefault(x => x.Cart_Id == id);
        }

        public int Insert(ClientCart item)
        {
            context.clientCart.Add(item);
            return context.SaveChanges();
        }

        public int Update(int id, ClientCart item)
        {
            ClientCart cart = GetById(id);
            if(cart!= null)
            {
                cart.Cart_Id = id;
                cart.Reservation_ID = item.Reservation_ID;
                cart.ID = item.ID;
                context.clientCart.Update(cart);
            }
            return context.SaveChanges();
        }
    }
}
