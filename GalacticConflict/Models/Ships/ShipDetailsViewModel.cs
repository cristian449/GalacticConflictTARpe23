﻿using IntergalacticConflict.Core.Dto;

namespace InterGalacticConflict.Models.Ships
{
    public class ShipDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ShipName { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public ShipClass ShipClass { get; set; }
        public int ShipHP { get; set; }
        public int ShipExperience { get; set; }
        public int Turbolaser { get; set; }
        public int Missile { get; set; }
        public int Torpedo { get; set; }
        public int Light_Laser { get; set; }
        public int Heavy_Laser { get; set; }
        public int Ballistic { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<ShipImageViewModel> Image { get; set; } = new List<ShipImageViewModel>();
    }
}
