﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.Domain
{
    public enum ShipClass
    {
        Frigate, Destroyer, Light_Cruiser, Heavy_Cruiser, Corvette, Capital, BattleCruiser, Super_Heavy_Battleship, Transport, Experimental
    }

    public enum ShipStatus
    {
        Destroyed, Guarding, Damaged, Active, Unshielded, Shielded, buffed
    }
    public class Ship
    {
        public Guid Id { get; set; }
        public string ShipName { get; set; }
        
        public ShipStatus ShipStatus { get; set; }
        public ShipClass  ShipClass { get; set; }

        public int ShipHP { get; set; }
        public int ShipExperience {  get; set; }
        public int TurbolaserPower { get; set; }
        public int Turbolaser { get; set; }
        public int MissilePower { get; set; }
        public int Missile { get; set; }
        public int TorpedoPower { get; set; }
        public int Torpedo { get; set; }
        public int Light_LaserPower { get; set; }
        public int Light_Laser { get; set; }
        public int Heavy_LaserPower { get; set; }
        public int Heavy_Laser { get; set; }
        public int BallisticPower { get; set; }
        public int Ballistic { get; set; }
        public DateTime ShipCreated { get; set; }
        public DateTime ShipDestroyed { get; set; }

        //Database only

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
