using IntergalacticConflict.Core.Domain;
using IntergalacticConflict.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticConflict.Core.ServiceInterface
{

        public interface IFileServices
        {
            void UploadFilesToDatabase(ShipDto dto, Ship domain);

            void UploadFilesToDatabase(PlanetDto dto, Planet domain);

            Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        }
}
