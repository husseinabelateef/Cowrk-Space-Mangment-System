using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class IncommingController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        IIncommingRepository incommingRepository;
        public IncommingController(UserManager<ApplicationUser> user, IIncommingRepository incomming)
        {
            userManager = user;
            incommingRepository=incomming;
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User);
        public IActionResult Show()
        {
            return View();
        }
        public async Task<IActionResult> ToatalPriceAsync()
        {
            var UserModel = await GetCurrentUserAsync();
            Incomming incomming1 = new Incomming();
            incomming1.AppuserID = UserModel.Id;
            List<Incomming> incommings = incommingRepository.GetAll();
            incommings = incommings.Where(r => r.AppuserID == UserModel.Id).ToList();
            foreach(var incomming in incommings)
            {
                incomming1.ShiftCloseReservationIncome += incomming.ShiftCloseReservationIncome;
            }
            return PartialView("_ToatalPriceIncoming", incomming1);
        }
        public async Task<IActionResult> ToatalCatringAsync()
        {
            var UserModel = await GetCurrentUserAsync();
            Incomming incomming1 = new Incomming();
            incomming1.AppuserID = UserModel.Id;
            List<Incomming> incommings = incommingRepository.GetAll();
            incommings = incommings.Where(r => r.AppuserID == UserModel.Id).ToList();
            foreach (var incomming in incommings)
            {
                incomming1.ShiftCloseCateringIncome += incomming.ShiftCloseCateringIncome;
            }
            return PartialView("_ToatalCatring", incomming1);
        }
    }
}
