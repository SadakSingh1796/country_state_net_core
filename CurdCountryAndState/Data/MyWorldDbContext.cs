using CurdCountryAndState.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace CurdCountryAndState.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> context) : base(context)
        {
        }

        public DbSet<Coutries> Tbl_Coutries { get; set; }
        public DbSet<States> Tbl_States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
