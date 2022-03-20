using Microsoft.AspNetCore.Mvc;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult GetAllAdmins()
        {
            return View();
        }
    }
}
