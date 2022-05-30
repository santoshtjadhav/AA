using System;

namespace AA.CommoditiesDashboard.ApplicationService.Response
{
    public class CommodityRunningPnlResponse
    {
        public string Commodity { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal RunningTotal { get; set; }

    }

}
