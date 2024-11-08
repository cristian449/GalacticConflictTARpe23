using IntergalacticConflict.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace InterGalacticConflict.Data
{
    public class InterGalacticConflictContext : DbContext
    {
        public InterGalacticConflictContext(DbContextOptions<InterGalacticConflictContext> options) : base(options) {}

        public DbSet<Ship> Ships { get; set; }

        public DbSet<FileToDatabase> FilesToDatabase { get; set; }

    }
}
