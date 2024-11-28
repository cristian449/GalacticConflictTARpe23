using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.ApplicationServices.Services;
using InterGalacticConflict.Data;
using InterGalacticConflict.Models.Planets;
using InterGalacticConflict.Models.Ships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == null) { return NotFound(); }

            var planet = await _planetsServices.DetailsAsync(id);

            if (planet == null) { return NotFound(); };

            var images = await _context.FilesToDatabase
                .Where(x => x.PlanetID == id)
                .Select(y => new PlanetImageViewModel
                {
                    PlanetID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new PlanetDeleteViewModel();

            vm.ID = planet.ID;
            vm.PlanetName = planet.PlanetName;
            vm.PlanetType = planet.PlanetType;
            vm.PlanetPopulation = planet.PlanetPopulation;
            vm.CapitalCity = planet.CapitalCity;
            vm.Major_cities = planet.Major_cities;
            vm.SpaceStation = planet.SpaceStation;
            vm.Image.AddRange(images);



            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var planetToDelete = await _planetsServices.Delete(id);
            if (planetToDelete == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Modify(Guid Id)
        {
            if (Id == null) { return NotFound(); }

            var planet = await _planetsServices.DetailsAsync(Id);
            if (planet == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.PlanetID == Id)
                 .Select(y => new PlanetImageViewModel
                 {
                     PlanetID = y.ID,
                     ImageID = y.ID,
                     ImageData = y.ImageData,
                     ImageTitle = y.ImageTitle,
                     Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                 }).ToArrayAsync();

            var vm = new PlanetCreateViewModel();

            vm.ID = planet.ID;
            vm.PlanetName = planet.PlanetName;
            vm.PlanetType = planet.PlanetType;
            vm.PlanetPopulation = planet.PlanetPopulation;
            vm.CapitalCity = planet.CapitalCity;
            vm.Major_cities = planet.Major_cities;
            vm.SpaceStation = planet.SpaceStation;
            vm.SpaceStationType = planet.SpaceStationType;
            vm.Image.AddRange(images);

            return View("Modify", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Modify(PlanetCreateViewModel vm)
        {
            var dto = new PlanetDto()
            {
                ID = (Guid)vm.ID,
                PlanetName = vm.PlanetName,
                PlanetType = (PlanetType)vm.PlanetType,
                GalaxyID = vm.GalaxyID,
                PlanetPopulation = vm.PlanetPopulation,
                SpaceStation = vm.SpaceStation,
                SpaceStationType = vm.SpaceStationType,
                Major_cities = vm.Major_cities,
                CapitalCity = vm.CapitalCity,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    ShipID = x.PlanetID,
                }).ToArray()
            };
            var result = await _planetsServices.Modify(dto);
            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveImage(Guid id)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = id
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
    }



}
