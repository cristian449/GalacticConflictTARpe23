using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.Domain
{
    public enum PlanetType
    {
        Ecumenopolis, Ice_wasteland, Terraformed, Desert, Volcanic, Jungle, Plains, Crystalized, Wasteland, Ocean, Star, Nebula, Blackhole, Nebula_Cluster, lifeless
    }

    //public enum PlanetStatus
    //{
    //    Occupied, Free, Destroyed, Unhinabited, Garrisoned, Pirates, Warlord
    //}

    public enum SpaceStationType
    {
        Manafacturing_Factory, Economic, Civillian, Military, ShipYard, None, Goliath //Goliath is a station that has very good 
                                                                                      //Defense however also has large upcost
    }

    //public enum DefenseType
    //{
    //    Heavy, Light, Very_light, Medium
    //}

    public class Planet
    {

            public Guid ID { get; set; }
            public string PlanetName { get; set; }

            public PlanetType PlanetType { get; set; }
           
           // public PlanetStatus? PlanetStatus { get; set; }

            public int PlanetPopulation { get; set; } //Most likely will remain aesthetic

           //public string? Planetinfo { get; set; } //Information about planet, buffs, history and such

            public Guid? GalaxyID { get; set; } //What galaxy what planet is in, might have to add a 4th part called galaxies,
                                               //though i'll add that later, possibly, maybe if not too lazy
            public int Major_cities { get; set; } 

            public string CapitalCity {  get; set; } //Just an aesthetic choice 

            public int AmountOfShipsonPlanet { get; set; } //Not on, but occupying, you get the gist

            public string? SpaceStation { get; set; } //Aesthetic

            // Might try adding  "public int SpaceStations { get; set; } To add multiple space stations to one planet

            public SpaceStationType SpaceStationType { get; set; } //For now just and aesthetic choice, might change later

            //public DefenseType? DefenseType { get; set; } //A Station can only have one Defense type

            //public int? DefensePower { get; set; } //Will add limit to defense power later probably


            //Database only!
            public DateTime CreatedAt { get; set; }
            public DateTime ModifiedAt { get; set; }
    }

}

    


