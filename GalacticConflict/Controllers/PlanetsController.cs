using InterGalacticConflict.Data;
using InterGalacticConflict.Models.Planets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;


namespace InterGalacticConflict.Controllers
{

    private readonly InterGalacticConflictContext _context;


    public PlanetsController(InterGalacticConflictContext context)
    {
        _context = context;
    }

    public class PlanetsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Planets
                .Select(x => new PlanetIndexViewModel
                {
                    Id = x.Id,
                    PlanetName = x.ShipName,
                    PlanetType = x.PlanetType,
                    PlanetLocation = x.PlanetLocation,
                    PlanetResouces = x.PlanetResouces,
                    PlanetPopulation = x.PlanetPopulation,
                });
            return View(resultingInventory);
        }
    }
}
