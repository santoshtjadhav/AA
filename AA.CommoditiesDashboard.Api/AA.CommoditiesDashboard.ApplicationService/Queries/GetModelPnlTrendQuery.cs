using AA.CommoditiesDashboard.ApplicationService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.ApplicationService.Queries
{
    public class GetModelPnlTrendQuery:IRequest<List<ModelPnlTrendResponse>>
    {
    }

}
