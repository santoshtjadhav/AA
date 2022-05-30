using AA.CommoditiesDashboard.ApplicationService.Handlers;
using AA.CommoditiesDashboard.ApplicationService.Mapping;
using AA.CommoditiesDashboard.ApplicationService.Queries;
using AA.CommoditiesDashboard.ApplicationService.Response;
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
    public class GetHistoricalDataHandlerTests
    {
        private GetAllHistoricalDataHandler _sut;
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
            List<HistoricalDataDto> historicalDataDtos = new List<HistoricalDataDto>();
            HistoricalDataDto historicalDataDto = new HistoricalDataDto
            {
                Model = "Model",
                Commodity = "Commodity",
                Contract = "Contract",
                ContractDate = System.DateTime.Today,
                NewTradeAction = 1,
                Pnl = 200m,
                Price = 200m,
                Position = 2
            };
            historicalDataDtos.Add(historicalDataDto);

            _aARepositoryMock.Setup(x => x.GetHistoricalDataAsync())
                .ReturnsAsync(historicalDataDtos);
            _mapperMock.Setup(x => x.MapHistoricalDataToHistoricalResponse(historicalDataDtos))
                .Returns(new List<Response.HistoricalDataResponse> { 
                new Response.HistoricalDataResponse { 
                    Commodity=historicalDataDto.Commodity,
                    Model=historicalDataDto.Model,                }
                });
                       
            GetAllHistoricalQuery query = new GetAllHistoricalQuery();
            _sut = new GetAllHistoricalDataHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.FirstOrDefault().Model, Is.EqualTo(historicalDataDto.Model));
            Assert.That(result.FirstOrDefault().Commodity, Is.EqualTo(historicalDataDto.Commodity));
            _mapperMock.Verify(x => x.MapHistoricalDataToHistoricalResponse(historicalDataDtos), Times.Once);
        }

        [Test]
        public async Task GetAllHistoricalData_ShouldReturnEmpty_WhenNoDataExists()
        {

            //Arange
            
            _aARepositoryMock.Setup(x => x.GetHistoricalDataAsync())
                .ReturnsAsync(()=>null);
            _mapperMock.Setup(x => x.MapHistoricalDataToHistoricalResponse(It.IsAny<List<HistoricalDataDto>>()))
                .Returns((List<HistoricalDataResponse>)null);

            GetAllHistoricalQuery query = new GetAllHistoricalQuery();
            _sut = new GetAllHistoricalDataHandler(_aARepositoryMock.Object, _mapperMock.Object);

            ////Act
            var result = await _sut.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.That(result, Is.Null);         
        }
    }
}