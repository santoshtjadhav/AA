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
    public class GetModelRunningPnlHandlerTests
    {
        private GetModelRunningPnlHandler _sut;
        private Mock<IAARepository> _aARepositoryMock;
        private Mock<IApplicationDataMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _aARepositoryMock = new Mock<IAARepository>();
            _mapperMock = new Mock<IApplicationDataMapper>();
        }

        [Test]
        public async Task GetAllHistoricalData_ShouldReturnData_WhenDataExists()
        {

            //Arange
            List<ModelRunningPnl> dtos = new List<ModelRunningPnl>();
            ModelRunningPnl dto = new ModelRunningPnl
            {
                Model = "Model",
                ContractDate = System.DateTime.Today,
                RunningTotal = 200m
            };
            dtos.Add(dto);

            _aARepositoryMock.Setup(x => x.GetModelRunningPnlAsync())
                .ReturnsAsync(dtos);
            _mapperMock.Setup(x => x.MapModelRunningPnlResponse(dtos))
                .Returns(new List<Response.ModelRunningPnlResponse> {
                new Response.ModelRunningPnlResponse {
                    Model=dto.Model,
                    ContractDate=dto.ContractDate,
                    RunningTotal=dto.RunningTotal
                } });

            GetModelRunningPnlQuery query = new GetModelRunningPnlQuery();
            _sut = new GetModelRunningPnlHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.FirstOrDefault().Model, Is.EqualTo(dto.Model));
            Assert.That(result.FirstOrDefault().RunningTotal, Is.EqualTo(dto.RunningTotal));
        }

        [Test]
        public async Task GetAllHistoricalData_ShouldReturnEmpty_WhenNoDataExists()
        {

            //Arange

            _aARepositoryMock.Setup(x => x.GetModelRunningPnlAsync())
                .ReturnsAsync(() => null);

            GetModelRunningPnlQuery query = new GetModelRunningPnlQuery();
            _sut = new GetModelRunningPnlHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Null);
        }
    }
}