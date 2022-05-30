using System;

namespace AA.CommoditiesDashboard.Infrastructure.Dtos
{
    public class CommodityRunningPnl
    {
        public string Commodity { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal RunningTotal { get; set; }

    }

}
