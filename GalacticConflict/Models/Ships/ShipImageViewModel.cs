namespace InterGalacticConflict.Models.Ships
{
    public class ShipImageViewModel
    {
        public Guid ImageID { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public string Image {  get; set; }

        public Guid ShipID { get; set; }
    }
}
