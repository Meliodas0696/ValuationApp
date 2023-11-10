using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValuationApp.Entities;

namespace ValuationApp.DataAccess.Configuration
{

    public class VesselConfiguration : IEntityTypeConfiguration<Vessel>
    {
        public void Configure(EntityTypeBuilder<Vessel> builder)
        {
            builder.ToTable("Vessels", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Valuations).WithOne(_ => _.Vessel).HasForeignKey(_ => _.VesselId);
        }
    }


}
