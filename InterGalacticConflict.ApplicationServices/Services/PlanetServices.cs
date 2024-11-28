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
    }
}
