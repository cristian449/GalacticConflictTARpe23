using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using InterGalacticConflict.Data;
using Microsoft.EntityFrameworkCore;


namespace InterGalacticConflict.ApplicationServices.Services
{
    public class ShipServices : IShipServices
    {
        private readonly InterGalacticConflictContext _context;
        private readonly IFileServices _fileServices; 


        public ShipServices(InterGalacticConflictContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        /// <summary>
        /// get deatils for one ship
        /// </summary>
        /// <param name="id"> Id of one ship to show extra info of</param>
        /// <returns>Resulting Ship</returns>

        public async Task<Ship>  DetailsAsync(Guid id)
        {
            var result = await _context.Ships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Ship> Create(ShipDto dto)
        {
            // set by service
            Ship ship = new Ship();

            ship.Id = Guid.NewGuid();
            ship.ShipHP = 100;
            //Add shield later!!!
            ship.ShipExperience = 0;
            ship.ShipStatus = IntergalacticConflict.Core.Domain.ShipStatus.Active;
            ship.ShipCreated = DateTime.Now;
            ship.ShipDestroyed = DateTime.Parse("01/01/9999 00:00:00");

            //set by user

            ship.ShipName = dto.ShipName;
            ship.ShipClass = (IntergalacticConflict.Core.Domain.ShipClass)dto.ShipClass;
            ship.Turbolaser = dto.Turbolaser;
            ship.TurbolaserPower = dto.TurbolaserPower;
            ship.Light_Laser = dto.Light_Laser;
            ship.Light_LaserPower = dto.Light_LaserPower;
            ship.Heavy_Laser = dto.Heavy_Laser;
            ship.Heavy_LaserPower = dto.Heavy_LaserPower;
            ship.Torpedo = dto.Torpedo;
            ship.TorpedoPower = dto.TorpedoPower;
            ship.Ballistic = dto.Ballistic;
            ship.BallisticPower = dto.BallisticPower;
            ship.Missile = dto.Missile;
            ship.MissilePower = dto.MissilePower;


            //Set for Database

            ship.CreatedAt = DateTime.Now;  
            ship.UpdatedAt = DateTime.Now;

            //files
            if(dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, ship);
            }

            await _context.Ships.AddAsync(ship);
            await _context.SaveChangesAsync();

            return ship;
        }

        public async Task<Ship> Update(ShipDto dto)
        {
            // set by service
            Ship ship = new Ship();

            ship.Id = dto.Id;
            ship.ShipHP = dto.ShipHP;
            //Add shield later!!!
            ship.ShipExperience = dto.ShipExperience;
            ship.ShipStatus = (IntergalacticConflict.Core.Domain.ShipStatus)dto.ShipStatus;
            ship.ShipCreated = dto.ShipCreated;
            ship.ShipDestroyed = dto.ShipDestroyed;

            //set by user

            ship.ShipName = dto.ShipName;
            ship.ShipClass = (IntergalacticConflict.Core.Domain.ShipClass)dto.ShipClass;
            ship.Turbolaser = dto.Turbolaser;
            ship.TurbolaserPower = dto.TurbolaserPower;
            ship.Light_Laser = dto.Light_Laser;
            ship.Light_LaserPower = dto.Light_LaserPower;
            ship.Heavy_Laser = dto.Heavy_Laser;
            ship.Heavy_LaserPower = dto.Heavy_LaserPower;
            ship.Torpedo = dto.Torpedo;
            ship.TorpedoPower = dto.TorpedoPower;
            ship.Ballistic = dto.Ballistic;
            ship.BallisticPower = dto.BallisticPower;
            ship.Missile = dto.Missile;
            ship.MissilePower = dto.MissilePower;


            //Set for Database

            ship.CreatedAt = DateTime.Now;
            ship.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, ship);
            }

            _context.Ships.Update(ship);
            await _context.SaveChangesAsync();

            return ship;

        }

        public async Task<Ship> Delete(Guid id)
        {
            var result = await _context.Ships
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Ships.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

    }
}
