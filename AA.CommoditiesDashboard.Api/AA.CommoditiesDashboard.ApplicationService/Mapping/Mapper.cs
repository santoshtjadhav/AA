using AA.CommoditiesDashboard.ApplicationService.Response;
using AA.CommoditiesDashboard.Infrastructure;
using AA.CommoditiesDashboard.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace AA.CommoditiesDashboard.ApplicationService.Mapping
{
    public class ApplicationDataMapper : IApplicationDataMapper
    {
        public List<CommodityRunningPnlResponse> MapCommodityRunningPnlResponse(List<CommodityRunningPnl> data)
        {
            return data.Select(x => new CommodityRunningPnlResponse
            {
                Commodity = x.Commodity,
                ContractDate = x.ContractDate,
                RunningTotal = x.RunningTotal
            }).ToList();
        }

        public List<HistoricalDataResponse> MapHistoricalDataToHistoricalResponse(List<HistoricalDataDto> dtos)
        {
            return dtos.Select(x => new HistoricalDataResponse
            {                
                Model=x.Model,
                Commodity =x.Commodity,
                Contract=x.Contract,
                ContractDate=x.ContractDate,
                NewTradeAction=x.NewTradeAction,    
                Pnl=x.Pnl,
                Positon=x.Position,
                Price=x.Price
            }).ToList();
        }

        public List<ModelPnlTrendResponse> MapModelPnlTrendResponse(List<ModelPnlTrend> data)
        {
            return data.Select(x => new ModelPnlTrendResponse
            {
                Model = x.Model,
                Contracts = x.Contracts,
                Pnls = x.Pnls
            }).ToList();
        }

        public List<ModelPriceTrendResponse> MapModelPriceTrendResponse(List<ModelPriceTrend> data)
        {
            return data.Select(x => new ModelPriceTrendResponse
            {
                Model = x.Model,
                Contracts = x.Contracts,
                Prices = x.Prices
            }).ToList();
        }

        public List<ModelRunningPnlResponse> MapModelRunningPnlResponse(List<ModelRunningPnl> data)
        {
            return data.Select(x => new ModelRunningPnlResponse
            {
                Model = x.Model,
                ContractDate = x.ContractDate,
                RunningTotal = x.RunningTotal
            }).ToList();

        }
    }
}
