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
         IProductRepository ProductRepository { get; }

        public CatringController(ICartRepository cartRepository , IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            ProductRepository = productRepository;
        }
        //[HttpPost]
        public IActionResult Index(int id) // Cart Id
        {
            Cart cart = cartRepository.GetById(id);
            if (cart != null)
            {
                var ProductsDetails = productDetail(cart.Products);
                ViewData["TotalPrice"] = cart.TotalPrice;
                ViewData["CartId"] = 12;//cart.ID;
                return View(ProductsDetails);
            }
            else
            {
                List<ProductsDetailsCartViewModel> det = new List<ProductsDetailsCartViewModel>();
                ProductsDetailsCartViewModel ite = new ProductsDetailsCartViewModel();
                ite.Name = "Manga";
                ite.guid = Guid.NewGuid();
                ite.price = 10;
                ite.Quantity = 5;
                //det.Add(ite);
                //det.Add(ite);
                //ite.ProductId = Guid.NewGuid() ;

                ViewData["CartId"] = 12;
                det.Add(ite);
                return View(det);
            }
            }
        private List<ProductsDetailsCartViewModel> productDetail(List<Product> products)
        {
            HashSet<Product> productsSet = new HashSet<Product>(products);
            List<ProductsDetailsCartViewModel> result = new List<ProductsDetailsCartViewModel>();
            foreach (var item in productsSet)
            {
                ProductsDetailsCartViewModel ite = new ProductsDetailsCartViewModel();
                ite.guid = item.Id;
                ite.price = item.SellingPrice;
                ite.Quantity = products.FindAll(x => x.Id == item.Id).Count;
                ite.Name = item.Name;
                result.Add(ite);
            }
            return result;
        }
        //[HttpPost]
        public IActionResult decrease (string guid, int CartId)
        {
            bool status;
            Guid guidd = Guid.Parse(guid);
            var res = decreeasing(guidd, CartId, out status);
            ViewData["status"] = status;
            if (status) { //مبدئيا                
                return Json(res);
            }
            
            ProductsDetailsCartViewModel dataa = new ProductsDetailsCartViewModel();
            dataa.Quantity = 7;
            dataa.price = 4;
            dataa.Name = "Hussein";
            dataa.guid = guidd;
            return Json(dataa);
            
        }
        private ProductsDetailsCartViewModel decreeasing(Guid guid, int CartId , out bool status)
        {
            Cart cart = cartRepository.GetById(CartId);
            if (cart != null)
            {
                List<ProductsDetailsCartViewModel> res = productDetail(cart.Products);
                var produt = cart.Products.FirstOrDefault(x => x.Id == guid);
                produt.ActualAmount++;
                var data = res.FirstOrDefault(x => x.guid == guid);
                ProductRepository.Update(produt.Id, produt);
                data.Quantity--;
                if(data.Quantity == 0)
                {
                    cartRepository.RemoveProductInCart(CartId, produt.Id);
                }
                cart.TotalPrice -= data.price;
               
                ViewData["TotalPrice"] = cart.TotalPrice;
                cartRepository.Update(cart.ID, cart);
                status = true;
                return data;
            }
            status = false;
            return null;
        }
        private ProductsDetailsCartViewModel increasing(Guid guid, int CartId, out bool status)
        {
            Cart cart = cartRepository.GetById(CartId);
            
            if (cart != null)
            {
                List<ProductsDetailsCartViewModel> res = productDetail(cart.Products);
                var produt = cart.Products.FirstOrDefault(x => x.Id == guid);
                var data = res.FirstOrDefault(x => x.guid == guid);
                if (produt.ActualAmount != 0)
                {
                    produt.ActualAmount--;
                    data.Quantity++;
                    ProductRepository.Update(produt.Id, produt);
                    cart.TotalPrice += data.price;
                    ViewData["TotalPrice"] = cart.TotalPrice;
                    cartRepository.Update(cart.ID, cart);
                    status = true;
                    return data;
                }
                status = false;
                return data;
            }
            status = false;
            return null;
        }
        public IActionResult Increase(string guid, int CartId)
        {
            bool status;
            Guid guidd = Guid.Parse(guid);
            var res = increasing(guidd, CartId, out status);
            ViewData["status"] = status;
            if (status) //مبدئيا 
            {
                return Json(res);
            }

            ProductsDetailsCartViewModel dataa = new ProductsDetailsCartViewModel();
            dataa.Quantity = 6;
            dataa.price = 4;
            dataa.Name = "Hussein";
            dataa.guid = guidd;
            return Json(dataa);
        }
        public IActionResult delete(string guid, int CartId)
        {
            Guid guidd = Guid.Parse(guid);
            var cart = cartRepository.GetById(CartId);
            var product = cart.Products.FirstOrDefault(p => p.Id == guidd);
           int result =  cartRepository.RemoveAllProductWithId(CartId, product.Id);
            if(result == 0)
                return Json("un SuccessFully");
            else
                return Json("Delete SuccessFully");
        }
        public IActionResult Pay(string cartid)
        {
           // cartRepository.confirmPay(int.Parse(cartid));
            return RedirectToAction("Catring", "Home", 1);
        }
    } 
    
}
