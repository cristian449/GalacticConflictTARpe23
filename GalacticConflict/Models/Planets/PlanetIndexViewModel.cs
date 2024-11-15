namespace InterGalacticConflict.Models.Planets
{

    public enum PlanetType
    {
        Frost, Volcanic, Gas_giant, Forest, Jungle, Ocean, Dead
    }

    public enum PlanetStatus
    {
        Occupied, Destroyed, Independant, Guarded
    }

    public enum PlanetResouces
    {
        Fuel, Basic_Materials, Advanced_Materials, Experimental_Materials, No_Resources
    }
    public class PlanetIndexViewModel
    {
        public Guid Id { get; set; }

        public string PlanetName { get; set; }

        public string PlanetLocation { get; set; }

        public PlanetStatus PlanetStatus { get; set; }
        public PlanetType PlanetType { get; set; }

        public PlanetResouces PlanetResouces { get; set; }

        
    }
}
