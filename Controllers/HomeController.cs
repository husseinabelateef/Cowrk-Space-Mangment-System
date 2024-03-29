﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cowrk_Space_Mangment_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientCart clientCartRepo;
        ICartProductsRepository cartProductsRepository;
        private readonly IProductRepository productRepository;
        public ICartRepository CartRepository;

        public HomeController(ILogger<HomeController> logger, ICartRepository cartRepository,
            IClientCart clientCartRepo, ICartProductsRepository cartProductsRepository
            , IProductRepository ProductRepository)
        {
            _logger = logger;

            this.cartProductsRepository = cartProductsRepository;
            productRepository = ProductRepository;
            CartRepository = cartRepository;
            this.clientCartRepo = clientCartRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Catring(int id)
        {
            List<Cart> carts;
            List<CartViewModel> cartViewModels;
            if (id == 3) //GetAll Carts
            {
                carts = CartRepository.GetAllUnpaidCart();
            }
            else if (id == 2) // Get All Clients Cart
            {
                carts = CartRepository.GetAllUnpaidClientsCart();
            }
            else // get All Vistors Cart
            {
                carts = CartRepository.GetAllUnpaidVistorsCart();
            }
            cartViewModels = cartViewModelsHelp(carts);
            return View(cartViewModels);
        }
        public List<CartViewModel> cartViewModelsHelp(List<Cart> carts)
        {
            List<CartViewModel> cartViewModels = new List<CartViewModel>();
            foreach (Cart c in carts)
            {
                CartViewModel asd = new CartViewModel();
                var cart = cartProductsRepository.GetAllProductOfCategory(c.ID);
                var lisPro = new List<Product>();
                foreach (var item in cart)
                {
                    lisPro.Add(productRepository.GetById(item.ProductId));
                }
                if (clientCartRepo.GetById(c.ID) != null)
                {
                    asd.ClientName = clientCartRepo.clientName(c.ID);
                    asd.CartId = c.ID;
                    asd.Products = lisPro;
                }
                if (asd.ClientName == null)
                {
                    asd.ClientName = "Visitor";
                    asd.CartId = c.ID;
                    asd.Products = lisPro;
                }
                cartViewModels.Add(asd);
            }
            return cartViewModels;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult classReservation()
        {
            return View();
        }
        public IActionResult IndividualReservation()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult updateNotify(string type)
        {
            try
            {
                int all = 0, visit = 0, client = 0;
                all = this.CartRepository.GetUnpaidCount();
                visit = this.CartRepository.GetAllUnpaidCountVistorsCart();
                client = this.CartRepository.GetAllUnpaidCountClientsCart();
                //data.all , data.visit , data.client status
                return Json(new { all = all, visit = visit, client = client, status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }

        }
    }
}