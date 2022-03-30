using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class IncommingController : Controller
    {
        IIncommingRepository incommingRepository;
       
        public IncommingController(IIncommingRepository incomming)
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
        public IActionResult ToatalPrice(int Id)
        {
            Incomming incomming=incommingRepository.GetById(Id);
            return View("_ToatalPriceIncoming",incomming);
        }
        public IActionResult ToatalCatring(int Id)
        {
            Incomming incomming = incommingRepository.GetById(Id);
            return View("_ToatalPriceIncoming", incomming);
        }
    }

}
