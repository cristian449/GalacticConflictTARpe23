using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Data;
using InterGalacticConflict.Models.Planets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterGalacticConflict.Controllers
{
    public class PlanetsController : Controller
    {
        private readonly InterGalacticConflictContext _context;
        private readonly IFileServices _fileServices;


        public PlanetsController(InterGalacticConflictContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }


        [HttpGet]
        public IActionResult Index() 
        {
            var allplanets = _context.Planets
            .OrderByDescending(a => a.PlanetType)
            .Select(x => new PlanetIndexViewModel
            {
                Id = x.Id,
                PlanetName = x.PlanetName,
                PlanetType = x.PlanetType,
                PlanetStatus = x.PlanetStatus,
                PlanetPopulation = x.PlanetPopulation,
                GalaxyID = x.GalaxyID,
                Major_cities = x.Major_cities,
                CapitalCity = x.CapitalCity,
                AmountOfShipsonPlanet = x.AmountOfShipsonPlanet,
                SpaceStation = x.SpaceStation,
                SpaceStationType = x.SpaceStationType,

            });

            return View(allplanets);
        }
    }
}
