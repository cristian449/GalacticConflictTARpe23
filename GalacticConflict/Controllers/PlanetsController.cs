using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.ApplicationServices.Services;
using InterGalacticConflict.Data;
using InterGalacticConflict.Models.Planets;
using InterGalacticConflict.Models.Ships;
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
                .OrderByDescending(y => y.PlanetType)
                .Select(x => new PlanetIndexViewModel
            {
                ID = x.ID,
                PlanetName = x.PlanetName,
                PlanetType = x.PlanetType,
                //PlanetStatus = (IntergalacticConflict.Core.Domain.PlanetStatus)x.PlanetStatus,
                PlanetPopulation = x.PlanetPopulation,
                GalaxyID = (Guid)x.GalaxyID,
                Major_cities = x.Major_cities,
                CapitalCity = x.CapitalCity,
                SpaceStation = x.SpaceStation,
                AmountOfShipsonPlanet = (int)x.AmountOfShipsonPlanet,
                
                

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
                PlanetType = (PlanetType)vm.PlanetType,
                //PlanetStatus = (PlanetStatus?)vm.PlanetStatus,
                GalaxyID = vm.GalaxyID,
                PlanetPopulation = vm.PlanetPopulation,
                SpaceStation = vm.SpaceStation,
                SpaceStationType = vm.SpaceStationType,
                Major_cities = vm.Major_cities,
                CapitalCity = vm.CapitalCity,

                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

                Files = vm.Files,
                Image = vm.Image

               .Select(x => new FileToDatabaseDto
                {
                     ID = x.ImageID,
                     ImageData = x.ImageData,
                     ImageTitle = x.ImageTitle,
                     PlanetID = x.PlanetID
                
               }).ToArray()
            };
            var addedplanet = await _planetsServices.Create(dto);
            if (addedplanet == null) 
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index", vm);
        }

        public async Task<IActionResult> Details(Guid Id /*, Guid ref*/)
        {
            var planet = await _planetsServices.DetailsAsync(Id);

            if (planet == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToDatabase
                .Where(s => s.PlanetID == Id)
                .Select(y => new PlanetImageViewModel
                {
                    PlanetID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();


            var vm = new PlanetDetailsViewModel();

            vm.ID = planet.ID;
            vm.PlanetName = planet.PlanetName;
            vm.PlanetType = planet.PlanetType;
            vm.PlanetPopulation = planet.PlanetPopulation;
            vm.CapitalCity = planet.CapitalCity;
            vm.Major_cities = planet.Major_cities;
            vm.SpaceStation = planet.SpaceStation;
            vm.SpaceStationType = planet.SpaceStationType;
            vm.Image.AddRange(images);

            return View(vm);

        }
    }
}
