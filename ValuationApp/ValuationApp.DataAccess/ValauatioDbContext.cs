using Microsoft.EntityFrameworkCore;
using ValuationApp.DataAccess.Configuration;
using ValuationApp.Entities;

namespace ValuationApp.DataAccess
{
    public class ValauatioDbContext : DbContext
    {
        public ValauatioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Valuation> Valuations { get; set; }
        public DbSet<Bundle> Bundles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VesselConfiguration());
            modelBuilder.ApplyConfiguration(new ValuationConfiguration());
            modelBuilder.ApplyConfiguration(new BundleConfiguration());
        }
    }
}