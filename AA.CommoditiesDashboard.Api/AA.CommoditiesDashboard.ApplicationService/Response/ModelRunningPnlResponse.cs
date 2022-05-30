using System;

namespace AA.CommoditiesDashboard.ApplicationService.Response
{
    public class ModelRunningPnlResponse
    {        
        public string Model { get; set; }        
        public DateTime ContractDate { get; set; }        
        public decimal RunningTotal { get; set; }

    }

}
