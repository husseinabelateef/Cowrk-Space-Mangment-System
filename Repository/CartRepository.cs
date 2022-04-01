using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class CartRepository : ICartRepository
    {
        Context context;
        private readonly IIncommingRepository incommingRepository;

        public CartRepository(Context _context , IIncommingRepository incommingRepository)
        {
            context = _context;
            this.incommingRepository = incommingRepository;
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
            return context.Cart.Where(x => !x.IsPaid).ToList();
        }

        public List<Cart> GetAllUnpaidVistorsCart()
        {
            return context.Cart.Where(x => !x.IsClient && !x.IsPaid).ToList();
        }

        public List<Cart> GetAllUnpaidClientsCart()
        {
            return context.Cart.Where(x => x.IsClient && !x.IsPaid).ToList();
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
            return GetAllUnpaidClientsCart().Count;
        }
        public int confirmPay(int CartId)
        {
            Cart cart = GetById(CartId);
            cart.TotalPrice = 
                context.CartProducts.Where(x => x.Cart_Id == cart.ID).Include(x => x.Product).
                Select(x => x.Quentaty * x.Product.SellingPrice ).Sum();
            cart.IsPaid = true;
            try
            {
                var income = context.Incomming.Last();
                income.ShiftCloseCateringIncome += cart.TotalPrice;
            }
            catch (Exception ex)
            {
                return context.SaveChanges();
            }
            return context.SaveChanges();

        }


        }
}