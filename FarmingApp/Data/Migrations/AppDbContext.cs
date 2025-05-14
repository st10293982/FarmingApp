using Microsoft.EntityFrameworkCore;
using FarmingApp.Models;

namespace FarmingApp.Data.Migrations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Farmers> Farmers { get; set; }
        public DbSet<FarmingItems> FarmingItems { get; set; }

    }
}

