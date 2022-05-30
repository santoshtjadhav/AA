using System;
using System.Collections.Generic;

namespace AA.CommoditiesDashboard.ApplicationService.Response
{
    public class ModelPnlTrendResponse
    {
        public string Model { get; set; }
        public List<string> Contracts { get; set; }
        public List<decimal> Pnls { get; set; }
        public ModelPnlTrendResponse()
        {
            Contracts = new List<string> { };
            Pnls = new List<decimal> { };
        }

    }

}
