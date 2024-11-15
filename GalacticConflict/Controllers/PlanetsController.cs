using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class PlanetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
