using AspNetCore;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Data;
using InterGalacticConflict.Models.Ships;
using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class ShipsController : Controller
    {

        /*
         Shipscontroller controlls all fuctions for Ships "Later more" fighters, resources etc.
         */
        private readonly InterGalacticConflictContext _context;
        private readonly IShipServices _ShipServices;

        public ShipsController(InterGalacticConflictContext context, IShipServices ShipServices)
        {
            _context = context;
            _ShipServices = ShipServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Ships
                .OrderByDescending(y => y.ShipExperience)
                .Select(x => new ShipIndexViewModel
                {
                    Id = x.Id,
                    ShipName = x.ShipName,
                    ShipExperience = x.ShipExperience,
                    ShipClass = (ShipClass)x.ShipClass,
                });
            return View(resultingInventory);
        }
    }
}
