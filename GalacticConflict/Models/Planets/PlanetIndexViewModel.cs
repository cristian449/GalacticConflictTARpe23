using IntergalacticConflict.Core.Domain;
using static IntergalacticConflict.Core.Domain.Planet;

namespace InterGalacticConflict.Models.Planets
{
   
    public class PlanetIndexViewModel
    {


        public Guid ID { get; set; }
        public string PlanetName { get; set; }

        public PlanetType PlanetType { get; set; }

        //public PlanetStatus? PlanetStatus { get; set; }

        public int PlanetPopulation { get; set; } 

        public Guid? GalaxyID { get; set; } 
        public int Major_cities { get; set; }

        public string CapitalCity { get; set; } 

        public int AmountOfShipsonPlanet { get; set; } 

        //public string? SpaceStation { get; set; } 
        // Might try adding  "public int SpaceStations { get; set; } To add multiple space stations to one planet

       // public SpaceStationType? SpaceStationType { get; set; }

        //Database only!
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
