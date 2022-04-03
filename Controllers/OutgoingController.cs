using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Controllers
{
    [Authorize]
    public class OutgoingController : Controller
    {
        IOutgoingRepository outgoingRepository;
        private UserManager<ApplicationUser> userManager;
        private async Task<ApplicationUser>
        GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User);

        public OutgoingController(IOutgoingRepository outgoing , UserManager<ApplicationUser> userManager )
        {
           outgoingRepository=outgoing;
           this.userManager=userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddingInfo([FromRoute] int id, Outgoing NewOut)
        {
            if (NewOut.Name != null)
            {
                var UserModel = await GetCurrentUserAsync();
                NewOut.Applicationuser.Id = UserModel.Id;
                outgoingRepository.Insert(NewOut);

                return RedirectToAction("AddingInfo");
            }
            List<Outgoing> OutgoingList = outgoingRepository.GetAll();
            ViewData["Outgoings"] = OutgoingList;
            return View("_AddingInformationOutgoing", NewOut);
        }


        [HttpPost]
        public IActionResult AddingInformation([FromRoute] int id, Outgoing NewOut)
        {
            if (NewOut.Name != null)
            {
              
                outgoingRepository.Insert(NewOut);
                
                return RedirectToAction("AddingInfo");
            }
            List<Outgoing> OutgoingList = outgoingRepository.GetAll();
            ViewData["Outgoings"] = OutgoingList;
            return View("_AddingInformationOutgoing", NewOut);
        }


    }
}
