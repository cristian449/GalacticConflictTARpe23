using IntergalacticConflict.Core.Dto;
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
        private readonly IPlanetsServices _planetsServices;


        public PlanetsController(InterGalacticConflictContext context, IPlanetsServices planetsServices, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
            _planetsServices = planetsServices;
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
                GalaxyID = (Guid)x.GalaxyID,
                Major_cities = x.Major_cities,
                CapitalCity = x.CapitalCity,
                AmountOfShipsonPlanet = (int)x.AmountOfShipsonPlanet,
                SpaceStation = x.SpaceStation,
                SpaceStationType = x.SpaceStationType,

            });

            return View(allplanets);


            
        }
        [HttpGet]
        public IActionResult Create()
        {
            PlanetCreateViewModel vm = new();
            return View("Create", vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (PlanetCreateViewModel vm)
        {

            var dto = new PlanetDto()
            {
                PlanetName = vm.PlanetName,
                PlanetType = vm.PlanetType,
                PlanetStatus = vm.PlanetStatus,
                GalaxyID = vm.GalaxyID,
                PlanetPopulation = vm.PlanetPopulation,
                Major_cities = vm.Major_cities,
                CapitalCity = vm.CapitalCity,
                SpaceStation = vm.SpaceStation,
                SpaceStationType = vm.SpaceStationType,

                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

                Files = vm.Files,
                Image = vm.Image

               .Select(x => new FileToDatabaseDto
                {
                     ID = x.ImageID,
                     ImageData = x.ImageData,
                     ImageTitle = x.ImageTitle,
                     PlanetID = x.PlanetID,
                
               }).ToArray()
            };
            var newerplanet = await _planetsServices.Create(dto);
            if (newerplanet == null) 
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index", vm);
        }
    }
}
