using AA.CommoditiesDashboard.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AA.CommoditiesDashboard.Infrastructure.Dtos;

namespace AA.CommoditiesDashboard.Infrastructure.Repository
{
    public class AARepository : IAARepository
    {
        private readonly AAContext _aAContext;
        private readonly IMapper _mapper;

        public AARepository(AAContext aAContext, IMapper mapper)
        {
            _aAContext = aAContext;
            _mapper = mapper;
        }

        public async Task<List<HistoricalDataDto>> GetHistoricalDataAsync()
        {
            var query = _aAContext.CommoditiesData.Include("Commodity").Include("Commodity.Model");
            var dto = await query.ToListAsync();
            return _mapper.MapCommodityDataToHistoricalData(dto);
        }

        public async Task<List<CommodityRunningPnl>> GetCommodityRunningPnlAsync()
        {
            var query = _aAContext.CommoditiesData.Include("Commodity");
            var dto = await query.ToListAsync();
            decimal currentTotal = 0;
            var runningTotal = dto
                                .Select(i =>
                                {

                                    currentTotal += i.PnlDaily;
                                    return new CommodityRunningPnl
                                    {
                                        Commodity = i.Commodity.Name,
                                        ContractDate = i.Date,
                                        RunningTotal = currentTotal
                                    };
                                }).ToList();

            return runningTotal;
        }

        public async Task<List<ModelRunningPnl>> GetModelRunningPnlAsync()
        {
            var query = _aAContext.CommoditiesData.Include("Commodity");
            var dto = await query.ToListAsync();
            decimal currentTotal = 0;
            var runningTotal = dto
                                .Select(i =>
                                {

                                    currentTotal += i.PnlDaily;
                                    return new ModelRunningPnl
                                    {
                                        Model = i.Commodity.Name,
                                        ContractDate = i.Date,
                                        RunningTotal = currentTotal
                                    };
                                }).ToList();

            return runningTotal;
        }

        public async Task<List<ModelPriceTrend>> GetModelPriceTrendAsync()
        {
            var query = _aAContext.CommoditiesData.Include("Commodity").Include("Commodity.Model"); ;
            var dto = await query.ToListAsync();


            var data = (from t in dto
                        group t by new { t.Commodity.Model.Name, t.Contract }
             into grp
                        select new
                        {
                            grp.Key.Name,
                            grp.Key.Contract,
                            Price = grp.Sum(t => t.Price)
                        }).ToList();
            List<ModelPriceTrend> modelPnlTrends = new List<ModelPriceTrend>();
            foreach (var item in data)
            {
                if (modelPnlTrends.Any(x => x.Model == item.Name))
                {
                    modelPnlTrends.Find(x => x.Model == item.Name).Prices.Add(item.Price);
                    modelPnlTrends.Find(x => x.Model == item.Name).Contracts.Add(item.Contract);
                }
                else
                {
                    ModelPriceTrend modelPnlTrend = new ModelPriceTrend();
                    modelPnlTrend.Model = item.Name;
                    modelPnlTrend.Contracts.Add(item.Contract);
                    modelPnlTrend.Prices.Add(item.Price);
                    modelPnlTrends.Add(modelPnlTrend);
                }

            }
            return modelPnlTrends; ;
        }

        public async Task<List<ModelPnlTrend>> GetModelPnlTrendAsync()
        {
            var query = _aAContext.CommoditiesData.Include("Commodity").Include("Commodity.Model"); ;
            var dto = await query.ToListAsync();


            var data = (from t in dto
                        group t by new { t.Commodity.Model.Name, t.Contract }
             into grp
                        select new 
                        {
                            grp.Key.Name,
                            grp.Key.Contract,
                            Pnl = grp.Sum(t => t.PnlDaily)
                        }).ToList();
            List<ModelPnlTrend> modelPnlTrends = new List<ModelPnlTrend>();
            foreach (var item in data)
            {
                if (modelPnlTrends.Any(x => x.Model == item.Name))
                {
                    modelPnlTrends.Find(x => x.Model == item.Name).Pnls.Add(item.Pnl);
                    modelPnlTrends.Find(x => x.Model == item.Name).Contracts.Add(item.Contract);
                }
                else {
                    ModelPnlTrend modelPnlTrend = new ModelPnlTrend();
                    modelPnlTrend.Model = item.Name;
                    modelPnlTrend.Contracts.Add(item.Contract);
                    modelPnlTrend.Pnls.Add(item.Pnl);
                    modelPnlTrends.Add(modelPnlTrend);
                }
                
            }
            return modelPnlTrends; ;
        }

    }
}
