using AA.CommoditiesDashboard.ApplicationService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.Controllers
{
    [Route("api/commodities")]
    [ApiController]
    public class CommoditiesController
    {

        private readonly IMediator _mediator;

        public CommoditiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("historicaldata")]
        public async Task<IActionResult> GetHistoricalData()
        {
            var query = new GetAllHistoricalQuery();

            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }

        [HttpGet("runningcommodity")]
        public async Task<IActionResult> GetCommodityRunningPnl()
        {
            var query = new GetCommodityRunningPnlQuery();

            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }


        [HttpGet("runningmodel")]
        public async Task<IActionResult> GetModelRunningPnl()
        {
            var query = new GetModelRunningPnlQuery();

            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }

        [HttpGet("modelpnltrend")]
        public async Task<IActionResult> GetModelPnlTrend()
        {
            var query = new GetModelPnlTrendQuery();

            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }


        [HttpGet("modelpricetrend")]
        public async Task<IActionResult> GetModelPriceTrend()
        {
            var query = new GetModelPriceTrendQuery();

            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }


    }
}
