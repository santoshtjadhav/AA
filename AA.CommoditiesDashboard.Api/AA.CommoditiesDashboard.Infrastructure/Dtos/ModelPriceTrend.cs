using System;
using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Infrastructure.Dtos
{
    public class ModelPriceTrend
    {        
        public string Model { get; set; }
        public List<string> Contracts { get; set; }
        public List<decimal> Prices { get; set; }
        public ModelPriceTrend()
        {
            Contracts = new List<string> { };
            Prices = new List<decimal> { };
        }

    }

}
