using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class ShipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
