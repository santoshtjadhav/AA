using AA.CommoditiesDashboard.ApplicationService.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Infrastructure.Repository;
using AA.CommoditiesDashboard.ApplicationService.Response;
using AA.CommoditiesDashboard.ApplicationService.Mapping;

namespace AA.CommoditiesDashboard.ApplicationService.Handlers
{ 

    public class GetCommodityRunningPnlHandler : IRequestHandler<GetCommodityRunningPnlQuery, List<CommodityRunningPnlResponse>>
    {
        private readonly IAARepository _aARepository;
        private readonly IApplicationDataMapper _mapper;

        public GetCommodityRunningPnlHandler(IAARepository aARepository, IApplicationDataMapper mapper)
        {
            _aARepository = aARepository;
            _mapper = mapper;
        }

        public async Task<List<CommodityRunningPnlResponse>> Handle(GetCommodityRunningPnlQuery request, CancellationToken cancellationToken)
        {
            var data = await _aARepository.GetCommodityRunningPnlAsync();
            return _mapper.MapCommodityRunningPnlResponse(data);
            
        }
    }
}
