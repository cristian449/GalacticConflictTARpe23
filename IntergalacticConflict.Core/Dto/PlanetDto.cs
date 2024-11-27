using IntergalacticConflict.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.Dto
{
    public class PlanetDto
    {
        public Guid Id { get; set; }
        public string PlanetName { get; set; }

        public PlanetType PlanetType { get; set; }

        public PlanetStatus PlanetStatus { get; set; }

        public int PlanetPopulation { get; set; }

        public Guid GalaxyID { get; set; }
        public int Major_cities { get; set; }

        public string CapitalCity { get; set; }

        public int AmountOfShipsonPlanet { get; set; }

        public string SpaceStation { get; set; }
        // Might try adding  "public int SpaceStations { get; set; } To add multiple space stations to one planet

        public SpaceStationType SpaceStationType { get; set; }


        //IGMAE YAY
        public List<IFormFile> Files { get; set; }

        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        //Database only!
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
