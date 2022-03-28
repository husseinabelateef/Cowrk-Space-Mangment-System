using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class HomeController : Controller
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly IClientCart clientCartRepo;

        public ICartRepository CartRepository { get; }

        public HomeController(ILogger<HomeController> logger , ICartRepository cartRepository ,
            IClientCart clientCartRepo)
        {
            _logger = logger;
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
        public IActionResult Catring()
        {
            List<Cart> carts = CartRepository.GetAllUnpaidCart();
            List<CartViewModel> cartViewModels = new List<CartViewModel>();
            foreach (Cart c in carts)
            {
                CartViewModel asd = new CartViewModel();
                    if( clientCartRepo.GetById(c.ID)!= null)
                    {

                    asd.ClientName = clientCartRepo.clientName(c.ID);
                    }
                    if(asd.ClientName == null)
                    {
                        asd.ClientName = "Visitor";
                        asd.CartId = c.ID;
                        asd.Products = c.Products;
                    }
                cartViewModels.Add(asd);
            }
            return View(cartViewModels);
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
    }
}
