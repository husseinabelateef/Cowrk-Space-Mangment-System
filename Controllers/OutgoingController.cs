using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class OutgoingController : Controller
    {
        IOutgoingRepository outgoingRepository;
        IRawProductMovmentRepository rawProductMovmentRepository;
        IProductMovementsRepository productMovementsRepository;

        public OutgoingController(IOutgoingRepository outgoing , IRawProductMovmentRepository rawProductMovment, IProductMovementsRepository productMovements)
        {
            outgoingRepository=outgoing;
            rawProductMovmentRepository=rawProductMovment;
            productMovementsRepository=productMovements;
        }
        public IActionResult GetAllOutgoing()
        {
            List<Outgoing> OutgoingList = outgoingRepository.GetAll();
            List<RawProductMovments> rawProductMovments = rawProductMovmentRepository.GetAll();
            List<ProductMovments> productMovments = productMovementsRepository.GetAll();
            ViewData["Outgoings"] = OutgoingList;
            ViewData["rawM"] = rawProductMovments;
            ViewData["productM"] = productMovments;
            return View("_AddingInformationOutgoing", OutgoingList);
           
        }
        [HttpPost]
        public IActionResult AddingInformation([FromRoute] int id, Outgoing NewOut)
        {
            if (NewOut.Name != null)
            {
              
                outgoingRepository.Insert(NewOut);
                
                return RedirectToAction("GetAllOutgoing");
            }

            List<Outgoing> OutgoingList = outgoingRepository.GetAll();
            List<RawProductMovments> rawProductMovments = rawProductMovmentRepository.GetAll();
            List<ProductMovments> productMovments = productMovementsRepository.GetAll();
            ViewData["Outgoings"] = OutgoingList;
            ViewData["rawM"] = rawProductMovments;
            ViewData["productM"] = productMovments;
            return View("GetAllOutgoing", NewOut);
        }

    }
}
