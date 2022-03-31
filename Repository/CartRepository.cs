using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class CartRepository: ICartRepository
    {
        Context context;
        public CartRepository(Context _context)
        {
            context = _context;
        }
        public List<Cart> GetAll()
        {
            return context.Cart.ToList();
        }

        public Cart GetById(int id)
        {
            return context.Cart.FirstOrDefault(Cart => Cart.ID == id);
        }

        public int Insert(Cart Cart)
        {
            context.Cart.Add(Cart);
            return context.SaveChanges();
        }

        public int Update(int id, Cart Cart)
        {
            Cart oldCart = GetById(id);
            if (oldCart != null)
            {
                oldCart.IsClient = Cart.IsClient;
                oldCart.TotalPrice = Cart.TotalPrice;
                oldCart.Date = Cart.Date;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Cart oldCart = GetById(id);
            context.Cart.Remove(oldCart);
            return context.SaveChanges();
        }

        public List<Cart> GetAllUnpaidCart()
        {
            return context.Cart.Where(x => x.IsPaid == false).ToList();
        }

        public List<Cart> GetAllUnpaidVistorsCart()
        {
            return context.Cart.Where(x => !x.IsClient && !x.IsPaid).ToList();
        }

        public List<Cart> GetAllUnpaidClientsCart()
        {
            return context.Cart.Where(x => x.IsClient && x.IsPaid).ToList();
        }

        public int GetUnpaidCount()
        {
            return GetAllUnpaidCart().Count;
        }

        public int GetAllUnpaidCountVistorsCart()
        {
            return GetAllUnpaidVistorsCart().Count;
        }

        public int GetAllUnpaidCountClientsCart()
        {
            return GetAllUnpaidVistorsCart().Count;
        } 
        public int confirmPay(int CartId)
        {
            Cart cart = GetById(CartId);
            cart.IsPaid = true;
           return  context.SaveChanges();

        }
    }
}
