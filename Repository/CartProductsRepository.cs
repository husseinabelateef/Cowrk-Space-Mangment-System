﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class CartProductsRepository : ICartProductsRepository
    {
        Context context;
        IProductRepository
            productRepository;
        ICartRepository cartRepository1;
        public CartProductsRepository(Context context , 
            ICartRepository  cartRepository, IProductRepository productRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
            this.cartRepository1 = cartRepository;  
        }
        public int Delete(int id)
        {
            var deletedProdu = context.CartProducts.Where(x => x.Cart_Id == id).ToList();
            foreach(var product in deletedProdu)
            {
                var prod = productRepository.GetById(product.ProductId);
                prod.ActualAmount += product.Quentaty;
                productRepository.Update(product.ProductId, prod);
                RemoveItem(product);
            }
            
            
            return context.SaveChanges();
        }

        public List<CartProducts> GetAll()
        {
            return context.CartProducts.ToList();
        }

        public CartProducts GetById(int id)
        {
            return context.CartProducts.FirstOrDefault(x => x.Cart_Id == id);
        }

        public int Insert(CartProducts item)
        {
            var test = context.CartProducts.FirstOrDefault(x => x.Cart_Id == item.Cart_Id &&
            x.ProductId == item.ProductId);
           
            Product prod = productRepository.GetById(item.ProductId);
            if (test == null)
            {
                context.CartProducts.Add(item);
            }
            else 
            { 
                 test.Quentaty += item.Quentaty;
            }
            prod.ActualAmount -= item.Quentaty;
            Cart cart = cartRepository1.GetById(item.Cart_Id);
            cart.TotalPrice += (item.Quentaty * prod.SellingPrice);
            cartRepository1.Update(item.Cart_Id , cart);
            productRepository.Update(prod.Id, prod);
            return context.SaveChanges();
        }

        public int Update(int id, CartProducts item)
        {
            CartProducts cart =  context.CartProducts.FirstOrDefault(x => x.ProductId == item.ProductId && x.Cart_Id == item.Cart_Id);
            Cart cart1 = null;
            if (cart != null)
            {
                if (cart.Quentaty != item.Quentaty)
                {
                    var tes = productRepository.GetById(item.ProductId);
                    tes.ActualAmount += cart.Quentaty;
                    tes.ActualAmount -= item.Quentaty;
                    if (cart.Quentaty > item.Quentaty)
                    {
                        cart1 = cartRepository1.GetById(cart.Cart_Id);
                        cart1.TotalPrice -= (cart.Quentaty - item.Quentaty) * tes.SellingPrice;
                    }
                    else
                    {
                        cart1 = cartRepository1.GetById(cart.Cart_Id);
                        cart1.TotalPrice += (cart.Quentaty - item.Quentaty) * tes.SellingPrice;
                    }
                    
                    productRepository.Update(tes.Id, tes);
                }
                cart.Quentaty = item.Quentaty;
                context.CartProducts.Update(cart);
            }
            return context.SaveChanges();
        }
        public List<CartProducts> GetAllProductOfCategory(int categoryId)
        {
            return context.CartProducts.Where(x => x.Cart_Id == categoryId).ToList();
        }
        //Remove an item form CartProducts and update Products
        public int RemoveItem(CartProducts item)
        {
            var product = productRepository.GetById(item.ProductId);
            product.ActualAmount += item.Quentaty;
            //update cart 
            var cart = cartRepository1.GetById(item.Cart_Id);
            cart.TotalPrice = cart.TotalPrice - (item.Quentaty * product.SellingPrice);
            cartRepository1.Update(item.Cart_Id, cart);
            context.CartProducts.Remove(item);
            context.Entry(item).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public CartProducts getAnItem(int cartId, Guid ProductId)
        {
            return context.CartProducts.FirstOrDefault(x => x.Cart_Id == cartId && x.ProductId == ProductId);
        }

        public int newUpdat(int quntity, CartProducts item)
        {
            CartProducts cart = getAnItem(item.Cart_Id, item.ProductId);
            Cart cart1 = null;
            if (cart != null)
            {
                if (quntity != cart.Quentaty)
                {
                    var tes = productRepository.GetById(item.ProductId);
                   
                    if (quntity > item.Quentaty)
                    {
                        tes.ActualAmount -= (quntity - item.Quentaty);
                        cart1 = cartRepository1.GetById(cart.Cart_Id);
                        cart1.TotalPrice += (quntity - item.Quentaty) * tes.SellingPrice;
                    }
                    else
                    {
                        cart1 = cartRepository1.GetById(cart.Cart_Id);
                        cart1.TotalPrice -= (item.Quentaty - quntity) * tes.SellingPrice;
                        tes.ActualAmount += ( item.Quentaty - quntity);
                    }
                    cartRepository1.Update(item.Cart_Id, cart1);
                    
                    productRepository.Update(tes.Id, tes);
                }
                cart.Quentaty = quntity;
                context.Entry(cart).State = EntityState.Modified;
                //context.CartProducts.Update(cart);
            }
            return context.SaveChanges();
        }
    }
}
