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
                .FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<Planet> Create(PlanetDto Dto)
        {
            Planet planet = new();

            planet.Id = Guid.NewGuid();
            planet.PlanetName = Dto.PlanetName;
            planet.PlanetPopulation = Dto.PlanetPopulation;
            planet.PlanetStatus = Dto.PlanetStatus;
            planet.CapitalCity = Dto.CapitalCity;
            planet.Major_cities = Dto.Major_cities;
            planet.PlanetType = Dto.PlanetType;
            planet.Planetinfo = Dto.Planetinfo;


            planet.CreatedAt = DateTime.Now;
            planet.ModifiedAt = DateTime.Now;

            //files
            if(Dto.Files !=  null)
            {
                _fileServices.UploadFilesToDatabase(Dto, planet);
            }

           
            return planet;





        }
    }
}
