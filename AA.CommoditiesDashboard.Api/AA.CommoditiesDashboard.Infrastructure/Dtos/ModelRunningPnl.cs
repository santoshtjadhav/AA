using System;

namespace AA.CommoditiesDashboard.Infrastructure.Dtos
{
    public class ModelRunningPnl
    {        
        public string Model { get; set; }        
        public DateTime ContractDate { get; set; }        
        public decimal RunningTotal { get; set; }

    }

}
