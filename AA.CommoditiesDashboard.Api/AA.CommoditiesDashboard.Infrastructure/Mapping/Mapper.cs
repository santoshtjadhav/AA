using AA.CommoditiesDashboard.Infrastructure.Dtos;
using AA.CommoditiesDashboard.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Infrastructure.Mapping
{
    public class Mapper : IMapper
    {    
        public List<HistoricalDataDto> MapCommodityDataToHistoricalData(List<CommodityData> dtos)
        {
            return dtos.Select(x => new HistoricalDataDto
            {                
                Model=x.Commodity.Model.Name,
                Commodity =x.Commodity.Name,
                Contract=x.Contract,
                ContractDate=x.Date,
                NewTradeAction=x.NewTradeAction,    
                Pnl=x.PnlDaily,
                Position=x.Position,
                Price=x.Price
            }).ToList();
        }
    }
}
