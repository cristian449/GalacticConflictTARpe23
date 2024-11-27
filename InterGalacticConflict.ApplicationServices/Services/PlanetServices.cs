using IntergalacticConflict.Core.Domain;
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
    }
}
