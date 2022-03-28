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
                ViewBag.TotalPrice = cart.TotalPrice;
                ViewBag.CartId = cart.ID;
                return View(ProductsDetails);
            }
            else
            {
                List<ProductsDetailsCartViewModel> det = new List<ProductsDetailsCartViewModel>();
                ProductsDetailsCartViewModel ite = new ProductsDetailsCartViewModel();
                ite.Name = "Manga";
                ite.BarCode = "Bar1";
                ite.price = 10;
                ite.Quantity = 5;
                //det.Add(ite);
                //det.Add(ite);
                //ite.ProductId = Guid.NewGuid() ;
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
                ite.BarCode = item.BarCode;
                ite.price = item.SellingPrice;
                ite.Quantity = products.FindAll(x => x.Id == item.Id).Count;
                ite.Name = item.Name;
                result.Add(ite);
            }
            return result;
        }
        [HttpPost]
        public IActionResult decrease (string BarCode, string CartId)
        {
           //Cart cart = cartRepository.GetById(int.Parse(CartId));
           //List<ProductsDetailsCartViewModel> res = productDetail(cart.Products);
           //var pro =  cart.Products.FirstOrDefault(x => x.BarCode == BarCode);
           //pro.ActualAmount++;
           //var data =  res.FirstOrDefault(x => x.BarCode == BarCode);
           // ProductRepository.Update(pro.Id , pro);
           // data.Quantity--;
            ProductsDetailsCartViewModel data = new ProductsDetailsCartViewModel();
            data.Quantity = 5;
            data.price = 4;
            data.Name = "Hussein";
            data.BarCode = "45";
            return Json(data);
            
        }
        public IActionResult Increase(string BarCode, string CartId)
        {
            //Cart cart = cartRepository.GetById(int.Parse(CartId));
            //List<ProductsDetailsCartViewModel> res = productDetail(cart.Products);
            //var pro = cart.Products.FirstOrDefault(x => x.BarCode == BarCode);
            //pro.ActualAmount--;
            //var data = res.FirstOrDefault(x => x.BarCode == BarCode);
            //ProductRepository.Update(pro.Id, pro);
            //data.Quantity++;
            ProductsDetailsCartViewModel data = new ProductsDetailsCartViewModel();
            data.Quantity = 5;
            data.price = 4;
            data.Name = "Hussein";
            data.BarCode = "45";
            return Json(data);
        }

    }
}
