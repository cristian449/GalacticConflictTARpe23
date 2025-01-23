using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IntergalacticConflict.Core.Dto
{
    public class FileToDatabaseDto
    {
        public Guid ID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? ShipID { get; set; }

        public Guid? PlanetID { get; set; }
    }
}