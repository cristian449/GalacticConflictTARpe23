using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;

namespace InterGalacticConflict.ApplicationServices.Services
{
    public class PlayerProfilesServices : IPlayersProfileServices
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerProfilesServices
            (
                UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
        }

        public async Task<PlayerProfile> Create( string useridfor)
        {
            var user = await _userManager.FindByIdAsync(useridfor);
            string userid = user.Id;
            var profile = new PlayerProfile()
            {
                ID = new Guid(),
                ApplicationUserID = userid,
                ScreenName = "",
                Credits = 100,
                BasicResource = 0, //Change later to other resource names and currency names
                Victories = 0,
                CurrentStatus = IntergalacticConflict.Core.Domain.ProfileStatus.Active,
                ProfileType = false,
                ProfileStatusLastChangedAt = DateTime.UtcNow,
                ProfileAttributedToAnAccountUserAt = DateTime.UtcNow,
                ProfileCreatedAt = DateTime.UtcNow,
                ProfileModifiedAt = DateTime.UtcNow,
            };
            return profile;

            //var resultforprofile = await _playerprofilesServices.Create(profile);
        }
    }
}
