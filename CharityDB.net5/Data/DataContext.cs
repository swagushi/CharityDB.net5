using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CharityDB.net5.Models;

namespace CharityDB.net5
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<CharityDB.net5.Models.donations> donations { get; set; }

        public DbSet<CharityDB.net5.Models.items> items { get; set; }
    }
}
