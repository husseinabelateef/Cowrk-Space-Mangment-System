using System;
using System.Collections.Generic;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.View_Model;
using Microsoft.AspNetCore.Mvc;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class CatringController : Controller
    {
        ICartRepository cartRepository;
        IProductRepository ProductRepository;
        ICartProductsRepository cartProductsRepository;

        public CatringController(ICartRepository cartRepository,
           ICartProductsRepository cartProductsRepository, IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            ProductRepository = productRepository;
            this.cartProductsRepository = cartProductsRepository;
        }
        //[HttpPost]
        public IActionResult Index(int id) // Cart Id
        {
            try
            {
                var cart = cartProductsRepository.GetAllProductOfCategory(id);
                var cart1 = cartRepository.GetById(id);
                var total = cart1.TotalPrice;
                List<ProductsDetailsCartViewModel> det = new List<ProductsDetailsCartViewModel>();
                foreach (var item in cart)
                {
                    ProductsDetailsCartViewModel ite = new ProductsDetailsCartViewModel();
                    var pro = ProductRepository.GetById(item.ProductId);
                    ite.guid = item.ProductId;
                    ite.price = pro.SellingPrice;
                    ite.Quantity = item.Quentaty;
                    ite.Name = pro.Name;
                    det.Add(ite);
                }
                ViewData["CartId"] = cart1.ID;
                return View(det);
            }
            catch (Exception ex)
            {
                return View(new List<ProductsDetailsCartViewModel> ());
            }
            
        }
        //[HttpPost]
        public IActionResult decrease(string guid, int CartId)
        {
            string message = "SucessFully ";
            CartProducts cartProd = null;
            Product product = null;
            bool status = true;
            try
            {

                Guid guidd = Guid.Parse(guid);
                ProductsDetailsCartViewModel dataa = new ProductsDetailsCartViewModel();
                cartProd = cartProductsRepository.getAnItem(CartId, guidd);
                product = this.ProductRepository.GetById(guidd);
                if (cartProd != null && this.ProductRepository.AvailabiltyStock(guidd, cartProd.Quentaty - 1))
                {
                    int q = cartProd.Quentaty - 1;
                    cartProductsRepository.newUpdat(q, cartProd);
                }
                else
                {
                    message = "out Of Stock";
                    status = false;
                }
                return Json(new
                {
                    status = status,
                    Message = message,
                    quentity = cartProd.Quentaty,
                    Name = product.Name,
                    price = product.SellingPrice,
                    guid = product.Id
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = status, Message = message });
            }
        }
        public IActionResult Increase(string guid, int CartId)
        {
            string message = "SucessFully added";
            CartProducts cartProd = null;
            Product product = null;
            bool status = true;
            try
            {
                
                Guid guidd = Guid.Parse(guid);
                ProductsDetailsCartViewModel dataa = new ProductsDetailsCartViewModel();
                 cartProd = cartProductsRepository.getAnItem(CartId, guidd);
                product = this.ProductRepository.GetById(guidd);
                if (cartProd != null && this.ProductRepository.AvailabiltyStock(guidd , cartProd.Quentaty+1))
                {
                    int q = cartProd.Quentaty + 1;
                    cartProductsRepository.newUpdat(q, cartProd);
                }
                else
                {
                    message = "out Of Stock";
                    status = false;
                }
                return Json(new {status = status , Message =message , 
                    quentity = cartProd.Quentaty , Name = product.Name ,price = product.SellingPrice ,
                    guid = product.Id
                });
            }
            catch (Exception ex) { 
                return Json(new { status = status, Message = message });
            }
        }
        public IActionResult delete(string guid, string CartId)
        {
            try
            {
                int cartid = 0;
                int.TryParse(CartId, out cartid);
             
                var it = cartProductsRepository.getAnItem(cartid,Guid.Parse(guid));
                var cart = cartRepository.GetById(cartid);
                int result = cartProductsRepository.RemoveItem(it);
                double totalPrice = cart.TotalPrice;
                if (result == 0)
                    return Json(new { totalprice = totalPrice});
                else
                    return Json(new { totalprice = totalPrice });
            }
            catch (Exception ex)
            {
                return Json("un SuccessFully");
            }
        }
        public IActionResult Pay(string cartid)
        {
            if (cartRepository.confirmPay(int.Parse(cartid)) != 0)
            {
                return Json(new {status = true , message = "Successful"});

            }
            else
            {
                return Json(new { status = false, message = "un Successful" });
            }

        }
    }

}