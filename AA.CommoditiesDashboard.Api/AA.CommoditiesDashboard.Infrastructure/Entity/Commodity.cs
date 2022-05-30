using System;

namespace AA.CommoditiesDashboard.Infrastructure.Entity
{
    public class Commodity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public Model Model { get; set; }
    }
}
