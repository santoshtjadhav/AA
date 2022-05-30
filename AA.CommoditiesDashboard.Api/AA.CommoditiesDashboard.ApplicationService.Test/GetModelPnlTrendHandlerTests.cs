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
    public class GetModelPnlTrendHandlerTests
    {
        private GetModelPnlTrendHandler _sut;
        private Mock<IAARepository> _aARepositoryMock;
        private Mock<IApplicationDataMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _aARepositoryMock = new Mock<IAARepository>();
            _mapperMock = new Mock<IApplicationDataMapper>();
        }

        [Test]
        public async Task GetModelPnlTrend_ShouldReturnData_WhenDataExists()
        {

            //Arange
            List<ModelPnlTrend> dtos = new List<ModelPnlTrend>();
            List<string> contracts = new List<string> { "Contracts" };
            List<decimal> pnls = new List<decimal> { 200m };
            ModelPnlTrend dto = new ModelPnlTrend
            {
                Model = "Model",
                Contracts = contracts,
                Pnls = pnls
            };
            dtos.Add(dto);

            _aARepositoryMock.Setup(x => x.GetModelPnlTrendAsync())
                .ReturnsAsync(dtos);
            _mapperMock.Setup(x => x.MapModelPnlTrendResponse(dtos))
                .Returns(new List<Response.ModelPnlTrendResponse> {
                new Response.ModelPnlTrendResponse {
                    Model=dto.Model,
                    Contracts=dto.Contracts,
                    Pnls=dto.Pnls
                } });

            GetModelPnlTrendQuery query = new GetModelPnlTrendQuery();
            _sut = new GetModelPnlTrendHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.FirstOrDefault().Model, Is.EqualTo(dto.Model));            
            _mapperMock.Verify(x => x.MapModelPnlTrendResponse(dtos), Times.Once);
        }

        [Test]
        public async Task GetModelPnlTrend_ShouldReturnEmpty_WhenNoDataExists()
        {

            //Arange

            _aARepositoryMock.Setup(x => x.GetModelPnlTrendAsync())
                .ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.MapModelPnlTrendResponse(It.IsAny<List<ModelPnlTrend>>()))
                .Returns((List<ModelPnlTrendResponse>)null);

            GetModelPnlTrendQuery query = new GetModelPnlTrendQuery();
            _sut = new GetModelPnlTrendHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Null);
            _mapperMock.Verify(x => x.MapModelPnlTrendResponse(It.IsAny<List<ModelPnlTrend>>()), Times.Once);
        }
    }
}