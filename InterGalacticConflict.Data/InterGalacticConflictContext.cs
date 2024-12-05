using IntergalacticConflict.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterGalacticConflict.Data
{
    public class InterGalacticConflictContext : IdentityDbContext<ApplicationUser>
    {
        public InterGalacticConflictContext(DbContextOptions<InterGalacticConflictContext> options) : base(options) {}

        public DbSet<Ship> Ships { get; set; }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<FileToDatabase> FilesToDatabase { get; set; }

        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
