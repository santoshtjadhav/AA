using AA.CommoditiesDashboard.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.CommoditiesDashboard.Infrastructure.Configuration
{
    internal class CommodityConfiguration : IEntityTypeConfiguration<Commodity>
    {
        public void Configure(EntityTypeBuilder<Commodity> builder)
        {
            builder.ToTable("Commodity");
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Model)
                .WithMany()
                .HasForeignKey(x => x.ModelId);
        }
    }
}
