using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CharityDB.net5.Models;

namespace CharityDB
{
    public class net5Context : DbContext
    {
        public net5Context (DbContextOptions<net5Context> options)
            : base(options)
        {
        }

        public DbSet<CharityDB.net5.Models.members> members { get; set; }

        public DbSet<CharityDB.net5.Models.donations> donations { get; set; }

        public DbSet<CharityDB.net5.Models.items> items { get; set; }
    }
}
