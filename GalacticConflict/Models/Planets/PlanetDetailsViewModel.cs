using IntergalacticConflict.Core.Domain;

namespace InterGalacticConflict.Models.Planets
{
    public class PlanetDetailsViewModel
    {
        public Guid ID { get; set; }
        public string PlanetName { get; set; }

        public PlanetType PlanetType { get; set; }

        // public PlanetStatus? PlanetStatus { get; set; }

        public int PlanetPopulation { get; set; }

        public Guid? GalaxyID { get; set; }
        public int Major_cities { get; set; }

        public string? CapitalCity { get; set; }

        public int AmountOfShipsonPlanet { get; set; }

        public string? SpaceStation { get; set; }
        // Might try adding  "public int SpaceStations { get; set; } To add multiple space stations to one planet

        public SpaceStationType SpaceStationType { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<PlanetImageViewModel> Image { get; set; } = new List<PlanetImageViewModel>();

    }
}
