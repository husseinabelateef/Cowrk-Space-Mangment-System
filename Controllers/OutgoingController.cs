using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class OutgoingController : Controller
    {
        IOutgoingRepository outgoingRepository;
        

        public OutgoingController(IOutgoingRepository outgoing )
        {
            outgoingRepository=outgoing;
           
        }

        [HttpGet]
        public IActionResult AddingInfo([FromRoute] int id, Outgoing NewOut)
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
