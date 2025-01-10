using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using InterGalacticConflict.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterGalacticConflict.Controllers
{
    public class PlayerprofilesController : Controller
    {
        
        
           
        private readonly InterGalacticConflictContext _context;
        public PlayerprofilesController(InterGalacticConflictContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_context.PlayerProfiles.OrderByDescending(x => x.ScreenName));
        }
        [HttpGet]
        public async Task<IActionResult> NewProfile()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //maybe change NewPlayerProfile as one is a post the other is a get
        public async Task<IActionResult> NewPlayerProfile(PlayerProfileDto dto)
        {
            if (dto.ApplicationUserID == null)
            {
                return View (Index);
            }
            var newprofile = new PlayerProfile()
            {
                ID = dto.ID,
                ApplicationUserID = dto.ApplicationUserID,
                ScreenName = "",
                Credits = 100,
                BasicResource = 0, //Change later to other resource names and currency names
                Victories = 0,
                CurrentStatus = ProfileStatus.Active,
                ProfileType = false,
                ProfileStatusLastChangedAt = DateTime.UtcNow,
                ProfileCreatedAt = DateTime.UtcNow,
                ProfileModifiedAt = DateTime.UtcNow,
            };
            var result = await _context.PlayerProfiles.AddAsync(newprofile);
            if (result != null)
            {
                return View ("Index");
            }
            
            return View();
            


        }


        [HttpGet]
        public async Task<IActionResult> NewPlayerProfile()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<Player>
        //[HttpGet]
        // method that gets the user the view for playerprofile info
        //[HttpPost]
        // method to generate new playerprofile, info is gotten from a view
        // that the player is directed to, right after confirmation.
        //[HttpGet]
        // method FOR ADMINS to get view for player profile modification
        //[HttpGet]
        // method FOR USERS to get SETTINGS view for player profile modification.
        //[HttpPost]
        // method FOR ADMINS and USERS to modify player profile
    }
}

