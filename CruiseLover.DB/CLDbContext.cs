using CruiseLover.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CruiseLover.DB
{
    public class CLDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CruiseDetail> CruiseDetails { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=CruiseLovers; Integrated Security = true");
        }
    }
}
