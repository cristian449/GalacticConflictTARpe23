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
    public class ShipServices : IShipServices
    {
        private readonly InterGalacticConflictContext _context;
        //private readonly IFileServices _fileServices; 


        public ShipServices (InterGalacticConflictContext context /*, IFileServices fileServices*/)
        {
            _context = context;
            //_fileservices = fileServices
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Id of one ship to show extra info of</param>
        /// <returns>Resulting Ship</returns>

        public async Task<Ship>  DetailsAsync(Guid id)
        {
            var result = await _context.Ships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
