using AA.CommoditiesDashboard.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Infrastructure.Repository
{
    public interface IAARepository
    {
        Task<List<HistoricalDataDto>> GetHistoricalDataAsync();
        Task<List<ModelRunningPnl>> GetModelRunningPnlAsync();
        Task<List<CommodityRunningPnl>> GetCommodityRunningPnlAsync();
        Task<List<ModelPnlTrend>> GetModelPnlTrendAsync();
        Task<List<ModelPriceTrend>> GetModelPriceTrendAsync();
    }
}