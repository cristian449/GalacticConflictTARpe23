
namespace InterGalacticConflict.ApplicationServices
{
    using IntergalacticConflict.Core.Domain;
    using IntergalacticConflict.Core.Dto;
    using IntergalacticConflict.Core.ServiceInterface;
    using InterGalacticConflict.Data;
    using Microsoft.Extensions.Hosting;

    namespace GalacticTitans.ApplicationServices.Services
    {
        public class FileServices : IFileServices
        {
            private readonly IHostEnvironment _webHost;
            private readonly InterGalacticConflictContext _context;
            public FileServices
                (
                    IHostEnvironment webHost,
                    InterGalacticConflictContext context
                )
            {
                _webHost = webHost;
                _context = context;
            }
            public void UploadFilesToDatabase(ShipDto dto, Ship domain)
            {
                if (dto.Files != null && dto.Files.Count > 0)
                {
                    foreach (var image in dto.Files)
                    {
                        using (var target = new MemoryStream())
                        {
                            FileToDatabase files = new FileToDatabase()
                            {
                                ID = Guid.NewGuid(),
                                ImageTitle = image.FileName,
                                ShipID = domain.Id
                            };
                            image.CopyTo(target);
                            files.ImageData = target.ToArray();
                            _context.FilesToDatabase.Add(files);
                        }
                    }
                }
            }
        }
    }
}
