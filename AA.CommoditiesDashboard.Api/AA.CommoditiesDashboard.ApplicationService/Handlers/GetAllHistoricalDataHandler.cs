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

    public class GetAllHistoricalDataHandler : IRequestHandler<GetAllHistoricalQuery, List<HistoricalDataResponse>>
    {
        private readonly IAARepository _aARepository;
        private readonly IApplicationDataMapper _mapper;

        public GetAllHistoricalDataHandler(IAARepository aARepository, IApplicationDataMapper mapper)
        {
            _aARepository = aARepository;
            _mapper = mapper;
        }

        public async Task<List<HistoricalDataResponse>> Handle(GetAllHistoricalQuery request, CancellationToken cancellationToken)
        {
            var historicalData = await _aARepository.GetHistoricalDataAsync();
            return _mapper.MapHistoricalDataToHistoricalResponse(historicalData);
            
        }
    }
}
