using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CharityDB.net5.Models;

namespace CharityDB.net5.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<CharityDB.net5.Models.members> members { get; set; }

        public DbSet<CharityDB.net5.Models.donations> donations { get; set; }
    }
}
