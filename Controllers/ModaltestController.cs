using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class ModaltestController : Controller
    {

        IReceptionistRepository ReceptionistRepository;

        public ModaltestController(IReceptionistRepository _ReceptionistRepository)
        {
            ReceptionistRepository = _ReceptionistRepository;
        }
        // GET: Home
        public ActionResult Index()
        {

                List<Receptionist> Receptionists = ReceptionistRepository.GetAll();
                return View(Receptionists);
          
        }

        [HttpPost]
        public ActionResult Details(string customerId)
        {
            Receptionist Receptionist = ReceptionistRepository.GetById(customerId);
            return PartialView("Details", Receptionist);
        }
    }
}
