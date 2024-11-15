namespace InterGalacticConflict.Models.Planets
{
    public class PlanetImageViewModel
    {
        public Guid ImageID { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public string Image { get; set; }

        public Guid PlanetID { get; set; }
    }
}
