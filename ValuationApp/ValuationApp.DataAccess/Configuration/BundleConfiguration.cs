using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValuationApp.Entities;

namespace ValuationApp.DataAccess.Configuration
{

    public class BundleConfiguration : IEntityTypeConfiguration<Bundle>
    {
        public void Configure(EntityTypeBuilder<Bundle> builder)
        {
            builder.ToTable("Bundles", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Valuations).WithOne(_ => _.Bundle).HasForeignKey(_ => _.VesselId);
        }
    }
}
