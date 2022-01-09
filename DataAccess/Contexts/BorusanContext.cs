using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class BorusanContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=OrderExamp;Trusted_Connection=true");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
