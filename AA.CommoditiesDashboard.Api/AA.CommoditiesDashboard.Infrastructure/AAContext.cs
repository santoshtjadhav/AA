using AA.CommoditiesDashboard.Infrastructure.Configuration;
using AA.CommoditiesDashboard.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Infrastructure
{
    public class AAContext : DbContext
    {
        public AAContext(DbContextOptions<AAContext> contextOptions)
           : base(contextOptions)
        {
        }

        internal virtual DbSet<Commodity> Commodities { get; set; }
        internal virtual DbSet<CommodityData> CommoditiesData { get; set; }
        internal virtual DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommodityConfiguration());
            builder.ApplyConfiguration(new CommodityDataConfiguration());
            builder.ApplyConfiguration(new ModelConfiguration());

        }
    }
}
