using AA.CommoditiesDashboard.Infrastructure.Dtos;
using AA.CommoditiesDashboard.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Infrastructure.Mapping
{
    public interface IMapper
    {
        List<HistoricalDataDto> MapCommodityDataToHistoricalData(List<CommodityData> dtos);

    }
}
