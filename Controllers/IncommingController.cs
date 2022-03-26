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
            incommingRepository=incomming;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ToatalPrice(int Id)
        {
            Incomming incomming=incommingRepository.GetById(Id);
            return PartialView("_ToatalPriceIncoming",incomming);
        }
        public IActionResult ToatalCatring(int Id)
        {
            Incomming incomming = incommingRepository.GetById(Id);
            return View(incomming);
        }
    }
}
