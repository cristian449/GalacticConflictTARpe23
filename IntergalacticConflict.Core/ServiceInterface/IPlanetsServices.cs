using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.ServiceInterface
{
    public interface IPlanetsServices
    {
        Task<Planet> DetailsAsync(Guid id);

        Task<Planet> Create(PlanetDto dto);
    }
}
