using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
using System.Diagnostics.Eventing.Reader;
using InterGalacticConflict.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterGalacticConflict.ApplicationServices.Services
{
    public class PlanetServices : IPlanetsServices

    {
        private readonly InterGalacticConflictContext _context;
        private readonly IFileServices _fileServices;



        public PlanetServices(InterGalacticConflictContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Planet> DetailsAsync(Guid id)
        {
            var result = await _context.Planets
                .FirstOrDefaultAsync(a => a.ID == id);
            
            return result;
        }

        public async Task<Planet> Create(PlanetDto dto)
        {
            Planet newplanet = new Planet();


            newplanet.ID = Guid.NewGuid();
            newplanet.PlanetName = dto.PlanetName;
            newplanet.PlanetPopulation = dto.PlanetPopulation;
            //newplanet.PlanetStatus = (IntergalacticConflict.Core.Domain.PlanetStatus?)dto.PlanetStatus;
            newplanet.CapitalCity = dto.CapitalCity;
            newplanet.Major_cities = dto.Major_cities;
            newplanet.PlanetType = (IntergalacticConflict.Core.Domain.PlanetType)dto.PlanetType;


            newplanet.CreatedAt = DateTime.Now;
            newplanet.ModifiedAt = DateTime.Now;

            //files
            if(dto.Files !=  null)
            {
                _fileServices.UploadFilesToDatabase(dto, newplanet);
            }

           await _context.Planets.AddAsync(newplanet);
           await _context.SaveChangesAsync();
           return newplanet;





        }

        public async Task<Planet> Delete(Guid id)
        {
            var result = await _context.Planets
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Planets.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Planet> Modify(PlanetDto dto)
        {
            // set by service
            Planet planet = new Planet();

            planet.ID = dto.ID;
            planet.PlanetName = dto.PlanetName;
            planet.PlanetPopulation = dto.PlanetPopulation;
            planet.PlanetType = (IntergalacticConflict.Core.Domain.PlanetType)dto.PlanetType;
            planet.CapitalCity = dto.CapitalCity;
            planet.Major_cities = dto.Major_cities;
            planet.SpaceStationType = dto.SpaceStationType;
            planet.SpaceStation = dto.SpaceStation;
            


            //Set for Database

            planet.CreatedAt = DateTime.Now;
            planet.ModifiedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, planet);
            }

            _context.Planets.Update(planet);
            await _context.SaveChangesAsync();

            return planet;

        }
    }
}
