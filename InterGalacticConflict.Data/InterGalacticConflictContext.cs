using IntergalacticConflict.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterGalacticConflict.Data
{
    internal class IntergalacticConflictContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
    }
}
