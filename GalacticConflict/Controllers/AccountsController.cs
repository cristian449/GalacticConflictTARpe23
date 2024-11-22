using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
