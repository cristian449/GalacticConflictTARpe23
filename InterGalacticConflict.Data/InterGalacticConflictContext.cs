using IntergalacticConflict.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterGalacticConflict.Data
{
    public class InterGalacticConflictContext : DbContext
    {
        public InterGalacticConflictContext(DbContextOptions<InterGalacticConflictContext> options) : base(options) {}

        public DbSet<Ship> Ships { get; set; }

    }
}
