using AA.CommoditiesDashboard.ApplicationService.Response;
using MediatR;
using System.Collections.Generic;

namespace AA.CommoditiesDashboard.ApplicationService.Queries
{
    public class GetModelPriceTrendQuery : IRequest<List<ModelPriceTrendResponse>>
    {
    }

}
