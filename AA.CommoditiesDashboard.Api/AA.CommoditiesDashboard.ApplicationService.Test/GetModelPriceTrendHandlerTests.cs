using AA.CommoditiesDashboard.ApplicationService.Handlers;
using AA.CommoditiesDashboard.ApplicationService.Mapping;
using AA.CommoditiesDashboard.ApplicationService.Queries;
using AA.CommoditiesDashboard.ApplicationService.Response;
using AA.CommoditiesDashboard.Infrastructure;
using AA.CommoditiesDashboard.Infrastructure.Dtos;
using AA.CommoditiesDashboard.Infrastructure.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.ApplicationService.Test
{
    public class GetModelPriceTrendHandlerTests
    {
        private GetModelPriceTrendHandler _sut;
        private Mock<IAARepository> _aARepositoryMock;
        private Mock<IApplicationDataMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _aARepositoryMock = new Mock<IAARepository>();
            _mapperMock = new Mock<IApplicationDataMapper>();
        }

        [Test]
        public async Task GetModelPriceTrend_ShouldReturnData_WhenDataExists()
        {

            //Arange
            List<ModelPriceTrend> dtos = new List<ModelPriceTrend>();
            List<string> contracts = new List<string> { "Contracts" };
            List<decimal> prices = new List<decimal> { 200m };
            ModelPriceTrend dto = new ModelPriceTrend
            {
                Model = "Model",
                Contracts = contracts,
                Prices = prices
            };
            dtos.Add(dto);

            _aARepositoryMock.Setup(x => x.GetModelPriceTrendAsync())
                .ReturnsAsync(dtos);
            _mapperMock.Setup(x => x.MapModelPriceTrendResponse(dtos))
                .Returns(new List<Response.ModelPriceTrendResponse> {
                new Response.ModelPriceTrendResponse {
                    Model=dto.Model,
                    Contracts=dto.Contracts,
                    Prices=dto.Prices
                }});

            GetModelPriceTrendQuery query = new GetModelPriceTrendQuery();
            _sut = new GetModelPriceTrendHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Not.Null);
            
            Assert.That(result.FirstOrDefault().Model, Is.EqualTo(dto.Model));            
            _mapperMock.Verify(x => x.MapModelPriceTrendResponse(dtos), Times.Once);
        }

        [Test]
        public async Task GetModelPriceTrend_ShouldReturnEmpty_WhenNoDataExists()
        {

            //Arange

            _aARepositoryMock.Setup(x => x.GetModelPriceTrendAsync())
                .ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.MapModelPriceTrendResponse(It.IsAny<List<ModelPriceTrend>>()))
                .Returns((List<ModelPriceTrendResponse>)null);

            GetModelPriceTrendQuery query = new GetModelPriceTrendQuery();
            _sut = new GetModelPriceTrendHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Null);
            _mapperMock.Verify(x => x.MapModelPriceTrendResponse(It.IsAny<List<ModelPriceTrend>>()), Times.Once);
        }
    }
}