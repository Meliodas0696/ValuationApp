using Microsoft.EntityFrameworkCore;
using ValuationApp.Entities;

namespace ValuationApp.DataAccess
{
    public class ValauatioDbContext : DbContext
    {
        public ValauatioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vessel> Vessels { get; set; }
    }
}