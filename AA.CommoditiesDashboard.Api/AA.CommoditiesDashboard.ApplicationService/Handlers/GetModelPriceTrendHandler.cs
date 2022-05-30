using AA.CommoditiesDashboard.ApplicationService.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Infrastructure.Repository;
using AA.CommoditiesDashboard.ApplicationService.Response;
using AA.CommoditiesDashboard.ApplicationService.Mapping;

namespace AA.CommoditiesDashboard.ApplicationService.Handlers
{
    public class GetModelPriceTrendHandler : IRequestHandler<GetModelPriceTrendQuery, List<ModelPriceTrendResponse>>
    {
        private readonly IAARepository _aARepository;
        private readonly IApplicationDataMapper _mapper;

        public GetModelPriceTrendHandler(IAARepository aARepository, IApplicationDataMapper mapper)
        {
            _aARepository = aARepository;
            _mapper = mapper;
        }

        public async Task<List<ModelPriceTrendResponse>> Handle(GetModelPriceTrendQuery request, CancellationToken cancellationToken)
        {
            var data = await _aARepository.GetModelPriceTrendAsync();
            return _mapper.MapModelPriceTrendResponse(data);

        }
    }

}
