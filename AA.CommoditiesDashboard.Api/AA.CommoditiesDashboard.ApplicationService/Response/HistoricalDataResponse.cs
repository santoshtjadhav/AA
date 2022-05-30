using System;

namespace AA.CommoditiesDashboard.ApplicationService.Response
{
    public class HistoricalDataResponse
    {
        public string Model { get; set; }
        public string Commodity { get; set; }
        public DateTime ContractDate { get; set; }
        public string Contract { get; set; }

        public decimal Price { get; set; }
        public int Positon { get; set; }
        public int NewTradeAction { get; set; }
        public decimal Pnl { get; set; }
    }
}