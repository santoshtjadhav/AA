using AA.CommoditiesDashboard.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.CommoditiesDashboard.Infrastructure.Configuration
{
    internal class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");
            builder.HasKey(x => x.Id);

        }
    }
}

