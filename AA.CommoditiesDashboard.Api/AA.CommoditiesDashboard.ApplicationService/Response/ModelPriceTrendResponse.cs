using System.Collections.Generic;

namespace AA.CommoditiesDashboard.ApplicationService.Response
{
    public class ModelPriceTrendResponse
    {
        public string Model { get; set; }
        public List<string> Contracts { get; set; }
        public List<decimal> Prices { get; set; }
        public ModelPriceTrendResponse()
        {
            Contracts = new List<string> { };
            Prices = new List<decimal> { };
        }

    }

}
