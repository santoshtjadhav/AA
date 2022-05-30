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
    public class GetCommodityRunningPnlHandlerTests
    {
        private GetCommodityRunningPnlHandler _sut;
        private Mock<IAARepository> _aARepositoryMock;
        private Mock<IApplicationDataMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _aARepositoryMock = new Mock<IAARepository>();
            _mapperMock = new Mock<IApplicationDataMapper>();
        }

        [Test]
        public async Task GetCommodityRunningPnl_ShouldReturnData_WhenDataExists()
        {

            //Arange
            List<CommodityRunningPnl> dtos = new List<CommodityRunningPnl>();
            CommodityRunningPnl dto = new CommodityRunningPnl
            {
                Commodity = "Commodity",
                ContractDate=System.DateTime.Today,
                RunningTotal=200m
            };
            dtos.Add(dto);

            _aARepositoryMock.Setup(x => x.GetCommodityRunningPnlAsync())
                .ReturnsAsync(dtos);
            _mapperMock.Setup(x => x.MapCommodityRunningPnlResponse(dtos))
                .Returns(new List<Response.CommodityRunningPnlResponse> {
                new Response.CommodityRunningPnlResponse {
                    Commodity=dto.Commodity,
                    ContractDate=dto.ContractDate,
                    RunningTotal=dto.RunningTotal
                } });

            GetCommodityRunningPnlQuery query = new GetCommodityRunningPnlQuery();
            _sut = new GetCommodityRunningPnlHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.FirstOrDefault().Commodity, Is.EqualTo(dto.Commodity));
            Assert.That(result.FirstOrDefault().RunningTotal, Is.EqualTo(dto.RunningTotal));            
        }

        [Test]
        public async Task GetCommodityRunningPnl_ShouldReturnEmpty_WhenNoDataExists()
        {

            //Arange
            
            _aARepositoryMock.Setup(x => x.GetCommodityRunningPnlAsync())
                .ReturnsAsync(()=>null);

            GetCommodityRunningPnlQuery query = new GetCommodityRunningPnlQuery();
            _sut = new GetCommodityRunningPnlHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Null);                      
        }
    }
}