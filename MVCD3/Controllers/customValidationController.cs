using Microsoft.AspNetCore.Mvc;

namespace MVCD3.Controllers
{
    public class customValidationController : Controller
    {
        public IActionResult ValidateLocation(string Location)
        {
            if (Location.Contains("Cairo"))
            {
                return Json(true);
            }
            else if (Location.Contains("Giza"))
            {
                return Json(true);
            }
            else if (Location.Contains("Alex"))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
