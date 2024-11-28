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
            Planet newplanet = new();

            newplanet.Id = Guid.NewGuid();
            newplanet.PlanetName = Dto.PlanetName;
            newplanet.PlanetPopulation = Dto.PlanetPopulation;
            newplanet.PlanetStatus = Dto.PlanetStatus;
            newplanet.CapitalCity = Dto.CapitalCity;
            newplanet.Major_cities = Dto.Major_cities;
            newplanet.PlanetType = Dto.PlanetType;


            newplanet.CreatedAt = DateTime.Now;
            newplanet.ModifiedAt = DateTime.Now;

            //files
            if(Dto.Files !=  null)
            {
                _fileServices.UploadFilesToDatabase(Dto, newplanet);
            }

           
            return newplanet;





        }
    }
}
