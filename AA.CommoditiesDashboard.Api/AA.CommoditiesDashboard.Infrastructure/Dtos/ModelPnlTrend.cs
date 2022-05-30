using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Infrastructure.Dtos
{
    public class ModelPnlTrend
    {
        public string Model { get; set; }
        public List<string> Contracts { get; set; }
        public List<decimal> Pnls { get; set; }
        public ModelPnlTrend()
        {
            Contracts = new List<string> { };
            Pnls = new List<decimal> { };
        }
    }

}
