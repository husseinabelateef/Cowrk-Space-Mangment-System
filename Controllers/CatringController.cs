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

        public CatringController(ICartRepository cartRepository , 
           ICartProductsRepository cartProductsRepository, IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            ProductRepository = productRepository;
            this.cartProductsRepository = cartProductsRepository;
        }
        //[HttpPost]
        public IActionResult Index(int id) // Cart Id
        {
            var cart = cartProductsRepository.GetAllProductOfCategory(id);
            var total = cartRepository.GetById(id).TotalPrice;
            var lisPro = new List<Product>();
            foreach (var item in cart)
            {
                lisPro.Add(ProductRepository.GetById(item.ProductId));
            }
            if (cart != null)
            {
                var ProductsDetails = productDetail(lisPro);
                ViewData["TotalPrice"] = total;
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
            Guid guidd;
            Guid.TryParse(guid , out guidd);
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
            try
            {
                var cart = cartProductsRepository.GetAllProductOfCategory(CartId);
                var lisPro = new List<Product>();
                foreach (var item in cart)
                {
                    lisPro.Add(ProductRepository.GetById(item.ProductId));
                }
                if (cart != null)
                {
                    List<ProductsDetailsCartViewModel> res = productDetail(lisPro);
                    var produt = lisPro.FirstOrDefault(x => x.Id == guid);
                    produt.ActualAmount++;
                    var data = res.FirstOrDefault(x => x.guid == guid);
                    ProductRepository.Update(produt.Id, produt);
                    data.Quantity--;
                    if (data.Quantity == 0)
                    {
                        var it = cartProductsRepository.getAnItem(CartId, produt.Id);
                        cartProductsRepository.RemoveItem(it);
                    }
                    cartRepository.GetById(cart.FirstOrDefault().Cart_Id).TotalPrice -= data.price;

                    ViewData["TotalPrice"] = cartRepository.GetById(cart.FirstOrDefault().Cart_Id).TotalPrice;
                    cartRepository.Update(CartId, cartRepository.GetById(cart.FirstOrDefault().Cart_Id));
                    status = true;
                    return data;
                }
                status = false;
                return null;
            }
            catch(Exception ex)
            {
                status = false;
                return null;
            }
        }
        private ProductsDetailsCartViewModel increasing(Guid guid, int CartId, out bool status)
        {
            try
            {
                Cart cart = cartRepository.GetById(CartId);
                var cartt = cartProductsRepository.GetAllProductOfCategory(CartId);
                var lisPro = new List<Product>();
                foreach (var item in cartt)
                {
                    lisPro.Add(ProductRepository.GetById(item.ProductId));
                }
                if (cart != null)
                {
                    List<ProductsDetailsCartViewModel> res = productDetail(lisPro);
                    var produt = lisPro.FirstOrDefault(x => x.Id == guid);
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
            catch (Exception ex)
            {
                status = false;
                return null;
            }
        }
        public IActionResult Increase(string guid, int CartId)
        {
            try
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
            catch(Exception ex) {  return Json(new ProductsDetailsCartViewModel()); }
            }
        public IActionResult delete(string guid, int CartId)
        {
            try
            {
                Guid guidd = Guid.Parse(guid);
                var cartt = cartProductsRepository.GetAllProductOfCategory(CartId);
                var lisPro = new List<Product>();
                foreach (var item in cartt)
                {
                    lisPro.Add(ProductRepository.GetById(item.ProductId));
                }
                var cart = cartRepository.GetById(CartId);
                var product = lisPro.FirstOrDefault(p => p.Id == guidd);
                var it = cartProductsRepository.getAnItem(CartId, product.Id);
                int result = cartProductsRepository.RemoveItem(it);

                if (result == 0)
                    return Json("un SuccessFully");
                else
                    return Json("Delete SuccessFully");
            }
            catch(Exception ex)
            {
                return Json("un SuccessFully");
            }
        }
        public IActionResult Pay(string cartid)
        {
           // cartRepository.confirmPay(int.Parse(cartid));
            return RedirectToAction("Catring", "Home", 1);
        }
    } 
    
}
