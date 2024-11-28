using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.ApplicationServices.Services;
using InterGalacticConflict.Data;
using InterGalacticConflict.Models.Ships;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace InterGalacticConflict.Controllers
{
    public class ShipsController : Controller
    {

        /*
         Shipscontroller controlls all fuctions for Ships "Later more" fighters, resources etc.
         */
        private readonly InterGalacticConflictContext _context;
        private readonly IShipServices _ShipServices;
        private readonly IFileServices _fileServices;

        public ShipsController(InterGalacticConflictContext context, IShipServices ShipServices, IFileServices fileServices)
        {
            _context = context;
            _ShipServices = ShipServices;
            _fileServices = fileServices;
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
                    ShipClass = (Models.Ships.ShipClass)x.ShipClass
                });
            return View(resultingInventory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ShipCreateViewModel vm = new();
            return View("Create", vm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed (ShipCreateViewModel vm)
        {
            var dto = new ShipDto()
            {
                ShipName = vm.ShipName,
                ShipHP = 100,
                //Add Shield later
                ShipExperience = 0,
                ShipClass = (IntergalacticConflict.Core.Dto.ShipClass)vm.ShipClass,
                ShipStatus = (IntergalacticConflict.Core.Dto.ShipStatus)vm.ShipStatus,
                Turbolaser = vm.Turbolaser,
                TurbolaserPower = vm.TurbolaserPower,
                Missile = vm.Missile,
                MissilePower = vm.MissilePower,
                Torpedo = vm.Torpedo,
                TorpedoPower = vm.TorpedoPower,
                Heavy_Laser = vm.Heavy_Laser,
                Heavy_LaserPower = vm.Heavy_LaserPower,
                Light_Laser = vm.Light_Laser,
                Light_LaserPower = vm.Light_LaserPower, 
                ShipCreated = vm.ShipCreated,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    ShipID = x.ShipID,
                }).ToArray()
            };
            var result = await _ShipServices.Create(dto);

            if (result != null) 
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }



        public async Task<IActionResult> Details(Guid Id /*, Guid ref*/)
        {
            var ship = await _ShipServices.DetailsAsync(Id);

            if (ship == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToDatabase
                .Where(s => s.ShipID == Id)
                .Select(y => new ShipImageViewModel
                {
                    ShipID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();


            var vm = new ShipDetailsViewModel();

            vm.Id = ship.Id;
            vm.ShipName = ship.ShipName;
            vm.ShipClass = (Models.Ships.ShipClass)ship.ShipClass;
            vm.ShipHP = ship.ShipHP;
            vm.ShipStatus = (Models.Ships.ShipStatus)ship.ShipStatus;
            vm.ShipExperience = ship.ShipExperience;
            vm.Turbolaser = ship.Turbolaser;
            vm.TurbolaserPower = ship.TurbolaserPower;
            vm.Missile = ship.Missile;
            vm.MissilePower = ship.MissilePower;
            vm.Torpedo = ship.Torpedo;
            vm.TorpedoPower = ship.TorpedoPower;
            vm.Light_Laser = ship.Light_Laser;
            vm.Light_LaserPower = ship.Light_LaserPower;
            vm.Heavy_Laser = ship.Heavy_Laser;
            vm.Heavy_LaserPower = ship.Heavy_LaserPower;
            vm.Ballistic = ship.Ballistic;
            vm.BallisticPower = ship.BallisticPower;
            vm.Image.AddRange(images);

            return View(vm);
            
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            if (Id == null) { return NotFound(); }

            var ship = await _ShipServices.DetailsAsync(Id);
            if (ship == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.ShipID == Id)
                 .Select(y => new ShipImageViewModel
                 {
                     ShipID = y.ID,
                     ImageID = y.ID,
                     ImageData = y.ImageData,
                     ImageTitle = y.ImageTitle,
                     Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                 }).ToArrayAsync();

            var vm = new ShipCreateViewModel();
            
                vm.Id = ship.Id;
                vm.ShipName = ship.ShipName;
                vm.ShipClass = (Models.Ships.ShipClass)ship.ShipClass;
                vm.ShipHP = ship.ShipHP;
                vm.ShipStatus = (Models.Ships.ShipStatus)ship.ShipStatus;
                vm.ShipExperience = ship.ShipExperience;
                vm.Turbolaser = ship.Turbolaser;
                vm.TurbolaserPower = ship.TurbolaserPower;
                vm.Missile = ship.Missile;
                vm.MissilePower = ship.MissilePower;
                vm.Torpedo = ship.Torpedo;
                vm.TorpedoPower = ship.TorpedoPower;
                vm.Light_Laser = ship.Light_Laser;
                vm.Light_LaserPower = ship.Light_LaserPower;
                vm.Heavy_Laser = ship.Heavy_Laser;
                vm.Heavy_LaserPower = ship.Heavy_LaserPower;
                vm.Ballistic = ship.Ballistic;
                vm.BallisticPower = ship.BallisticPower;
                vm.ShipDestroyed = ship.ShipDestroyed;
                vm.ShipCreated = ship.ShipCreated;
                vm.CreatedAt = ship.CreatedAt;
                vm.UpdatedAt = DateTime.Now;
                vm.Image.AddRange(images);

            return View("Update", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Update(ShipCreateViewModel vm)
        {
            var dto = new ShipDto()
            {
                Id = (Guid)vm.Id,
                ShipName = vm.ShipName,
                ShipHP = 100,
                //Add Shield later
                ShipExperience = 0,
                ShipClass = (IntergalacticConflict.Core.Dto.ShipClass)vm.ShipClass,
                ShipStatus = (IntergalacticConflict.Core.Dto.ShipStatus)vm.ShipStatus,
                Turbolaser = vm.Turbolaser,
                TurbolaserPower = vm.TurbolaserPower,
                Missile = vm.Missile,
                MissilePower = vm.MissilePower,
                Torpedo = vm.Torpedo,
                TorpedoPower = vm.TorpedoPower,
                Heavy_Laser = vm.Heavy_Laser,
                Heavy_LaserPower = vm.Heavy_LaserPower,
                Light_Laser = vm.Light_Laser,
                Light_LaserPower = vm.Light_LaserPower, 
                ShipCreated = vm.ShipCreated,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    ShipID = x.ShipID,
                }).ToArray()
            };
            var result = await _ShipServices.Update(dto);
            if (result == null) { return RedirectToAction("Index");  }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            if (id == null) { return NotFound(); }
            
            var ship = await _ShipServices.DetailsAsync(id);
           
            if (ship == null) { return NotFound(); };
            
            var images = await _context.FilesToDatabase
                .Where(x => x.ShipID == id)
                .Select(y => new ShipImageViewModel
                {
                    ShipID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new ShipDeleteViewModel();

            // TBC
            vm.Id = ship.Id;
            vm.ShipName = ship.ShipName;
            vm.ShipClass = (Models.Ships.ShipClass)ship.ShipClass;
            vm.ShipHP = ship.ShipHP;
            vm.ShipStatus = (Models.Ships.ShipStatus)ship.ShipStatus;
            vm.ShipExperience = ship.ShipExperience;
            vm.Turbolaser = ship.Turbolaser;
            vm.Missile = ship.Missile;
            vm.Torpedo = ship.Torpedo;
            vm.Light_Laser = ship.Light_Laser;
            vm.Heavy_Laser = ship.Heavy_Laser;
            vm.Ballistic = ship.Ballistic;
            vm.CreatedAt = ship.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);



            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var titanToDelete = await _ShipServices.Delete(id);
            if (titanToDelete == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
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
