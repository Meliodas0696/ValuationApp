using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValuationApp.Entities;

namespace ValuationApp.DataAccess.Configuration
{

    public class ValuationConfiguration : IEntityTypeConfiguration<Valuation>
    {
        public void Configure(EntityTypeBuilder<Valuation> builder)
        {
            builder.ToTable("Valuations", "dbo").HasKey(x => x.Id);
            builder.HasOne(_ => _.Vessel).WithMany(_ => _.Valuations).HasForeignKey(_ => _.VesselId);
            builder.HasOne(_ => _.Bundle).WithMany(_ => _.Valuations).HasForeignKey(_ => _.BundleId);
        }
    }
}
