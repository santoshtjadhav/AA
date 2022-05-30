using AA.CommoditiesDashboard.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.CommoditiesDashboard.Infrastructure.Configuration
{
    internal class CommodityDataConfiguration : IEntityTypeConfiguration<CommodityData>
    {
        public void Configure(EntityTypeBuilder<CommodityData> builder)
        {
            builder.ToTable("CommodityData");
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Commodity)
                .WithMany()
                .HasForeignKey(x => x.CommodityId);
        }
    }
}
