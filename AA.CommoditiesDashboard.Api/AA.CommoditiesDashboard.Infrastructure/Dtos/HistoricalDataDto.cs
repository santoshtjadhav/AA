using System;

namespace AA.CommoditiesDashboard.Infrastructure.Dtos
{
    public class HistoricalDataDto
    {        
        public string Model { get; set; }
        public string Commodity { get; set; }
        public DateTime ContractDate { get; set; }
        public string Contract { get; set; }

        public decimal Price { get; set; }
        public int Position { get; set; }
        public int NewTradeAction { get; set; }
        public decimal Pnl { get; set; }


    }
}
