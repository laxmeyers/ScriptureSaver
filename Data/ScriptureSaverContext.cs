using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureSaver.Models;

namespace ScriptureSaver.Data
{
    public class ScriptureSaverContext : DbContext
    {
        public ScriptureSaverContext (DbContextOptions<ScriptureSaverContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureSaver.Models.Scripture> Scripture { get; set; } = default!;
    }
}
