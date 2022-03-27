using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class CatringController : Controller
    {

        //[HttpPost]
        public IActionResult Index(int id)
        {
            
            return View();
        }

    }
}
