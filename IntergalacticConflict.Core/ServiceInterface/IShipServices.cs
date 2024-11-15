using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.ServiceInterface
{
    public interface IShipServices
    {
        Task<Ship> DetailsAsync(Guid id);

        Task<Ship> Create(ShipDto dto);
        Task<Ship> Update(ShipDto dto);

        Task<Ship> Delete(Guid id);
    }
}
