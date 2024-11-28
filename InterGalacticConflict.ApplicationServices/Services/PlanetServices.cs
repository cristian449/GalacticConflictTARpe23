using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using IntergalacticConflict.Core.ServiceInterface;
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


        public PlanetServices(InterGalacticConflictContext context)
        {
            _context = context;
        }

        public async Task<Planet> DetailsAsync(Guid id)
        {
            var result = await _context.Planets
                .FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<Planet> Create(PlanetDto Dto)
        {
            Planet newPlanet = new();

            newPlanet.Id = Guid.NewGuid();
            newPlanet.PlanetName = Dto.PlanetName;
            newPlanet.PlanetPopulation = Dto.PlanetPopulation;
            newPlanet.PlanetStatus = Dto.PlanetStatus;
            newPlanet.CapitalCity = Dto.CapitalCity;
            newPlanet.Major_cities = Dto.Major_cities;
            newPlanet.PlanetType = Dto.PlanetType;
            newPlanet.Planetinfo = Dto.Planetinfo;


            newPlanet.CreatedAt = DateTime.Now;
            newPlanet.ModifiedAt = DateTime.Now;

            if (dto.files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, newPlanet);
            }

            await _context.Planets.AddAsync(newPlanet);
            await _context.SaveChangesAsync();
            return newPlanet;





        }
    }
}
