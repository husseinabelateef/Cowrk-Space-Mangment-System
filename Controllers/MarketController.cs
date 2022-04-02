using System;
using System.Linq;
using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class MarketController : Controller
    {
        private ICartRepository cartRepository;
        private IProductRepository productRepository;
        private IClientCart clientCart;
        private IClientRepository clientRepository;
        private readonly ICartProductsRepository cartProductsRepository;
        private readonly IClientRepository clientRepository1;
        private IReservationRepository reservationRepository;

        public MarketController(IProductRepository productRepository,
            IClientCart clientCart, ICartRepository CartRepository,
            IReservationRepository reservationRepository, IClientRepository clientRepo
            , ICartProductsRepository cartProductsRepository , IClientRepository clientRepository)
        {
            this.cartRepository = CartRepository;
            this.productRepository = productRepository;
            this.clientCart = clientCart;
            this.clientRepository = clientRepo;
            this.cartProductsRepository = cartProductsRepository;
            clientRepository1 = clientRepository;
            this.reservationRepository = reservationRepository;
        }
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult ClientView()
        {
            return PartialView();
        }
        public IActionResult Cart(string userId = "Visitor")
        {
            try
            {
                Cart cart;
                if (userId == "Visitor")
                {
                    cart = new();
                    cart.IsClient = false;
                    cart.IsPaid = false;
                    cart.Date = DateTime.Now;
                    cartRepository.Insert(cart);
                }
                else
                {

                    cart = reservationRepository.GetLastCartForUser(int.Parse(userId));
                    
                }
                return PartialView(cart);
            }
            catch (Exception ex)
            {
                return PartialView(new Cart());
            }
            }
            public IActionResult AddingToCart(string productId, string CartId, string quntity)
            {
            string msg;
            bool flag = false;
            try
            {
                Product product = productRepository.GetByBarCode(productId);
               
                 msg = "Successfully";
                if (product != null)
                {
                    Guid IDd = product.Id;
                    var flagavail = productRepository.AvailabiltyStock(IDd, int.Parse(quntity));
                    Cart cart = cartRepository.GetById(int.Parse(CartId));
                    int finalQuentity = 0;

                    if (cart != null)
                    {
                        if (flagavail)
                        {
                            CartProducts cartPro = new CartProducts();
                            cartPro.ProductId = IDd;
                            cartPro.Cart_Id = int.Parse(CartId);
                            cartPro.Quentaty = int.Parse(quntity);
                            cartProductsRepository.Insert(cartPro);
                            CartProducts test = cartProductsRepository.getAnItem(int.Parse(CartId), IDd);
                            finalQuentity = test.Quentaty;
                            flag = true;
                        }
                        else
                        {
                            msg = "Out Of Stock";
                        }
                    }
                    else
                    {
                        msg = "Cart Not Exist";
                    }
                    return Json(new
                    {
                        message = msg,
                        quentity = finalQuentity,
                        productID = productId,
                        price = product.SellingPrice,
                        totalprice = cart.TotalPrice,
                        status = flag,
                        name = product.Name
                    });
                }
                msg = "Product NotFound";
                return Json(new { message = msg, status = flag });
            }
            catch (Exception ex)
            {
                msg = "Product NotFound";
                return Json(new { message = msg, status = flag });
            }

            }
        public IActionResult update(string productId, string CartId, string quntity)
        {
            var msg = "Suceesfully";
            bool status = false;
            Cart cart = null;
            int newQun = 0, newCartID = 0;
            try
            {
                
              
               Product product =  productRepository.GetByBarCode(productId);
                int.TryParse(quntity, out newQun);
                int.TryParse(CartId, out newCartID);
                bool ava = productRepository.AvailabiltyStock(product.Id, newQun);
                var cartItem = cartProductsRepository.getAnItem(newCartID, product.Id);
                if (productId != null && cartItem != null)
                {
                    if (ava)
                    {
                        
                        cartProductsRepository.newUpdat(newQun, cartItem);
                        cart = cartRepository.GetById(int.Parse(CartId));
                        status = true;
                    }
                    else
                    {
                        msg = "OutOfStock";
                    }
                }
                else
                {
                    msg = "Product Not Exist";
                }
               
             return Json(new { message = msg, guid = productId,
                 totalprice = cart.TotalPrice,
                 quantity = newQun, status = status });
            }
            catch (Exception ex)
            {
                return Json(new { message = msg, status = status });
            }
            }
        public IActionResult checkClient(string barcode)
        {
            Client client = clientRepository1.getByQrco(barcode);

            if (client == null)
            {
                return Json(new { status = false, userId = "Ahmed" });
            }
            return Json(new { status = true, userId = client.ID });
        }
        public IActionResult delete(string guid, string CartId)
        {
            try
            {
                int cartid = 0;
                int.TryParse(CartId, out cartid);
                var produ = productRepository.GetByBarCode(guid);
                var it = cartProductsRepository.getAnItem(cartid, produ.Id);
                var cart = cartRepository.GetById(cartid);
                int result = cartProductsRepository.RemoveItem(it);
                double totalPrice = cart.TotalPrice;
                if (result == 0)
                    return Json(new { totalprice = totalPrice });
                else
                    return Json(new { totalprice = totalPrice });
            }
            catch (Exception ex)
            {
                return Json("un SuccessFully");
            }
        }
    }
}