using AA.CommoditiesDashboard.ApplicationService.Response;
using AA.CommoditiesDashboard.Infrastructure;
using AA.CommoditiesDashboard.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.ApplicationService.Mapping
{
    public interface IApplicationDataMapper
    {
        List<HistoricalDataResponse> MapHistoricalDataToHistoricalResponse(List<HistoricalDataDto> dtos);
        List<CommodityRunningPnlResponse> MapCommodityRunningPnlResponse(List<CommodityRunningPnl> data);
        List<ModelRunningPnlResponse> MapModelRunningPnlResponse(List<ModelRunningPnl> data);
        List<ModelPnlTrendResponse> MapModelPnlTrendResponse(List<ModelPnlTrend> data);
        List<ModelPriceTrendResponse> MapModelPriceTrendResponse(List<ModelPriceTrend> data);
    }
}
