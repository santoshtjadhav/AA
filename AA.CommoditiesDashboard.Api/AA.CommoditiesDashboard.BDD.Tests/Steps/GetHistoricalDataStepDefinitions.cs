using System;
using TechTalk.SpecFlow;
using RestSharp;
using AA.CommoditiesDashboard.ApplicationService.Response;

namespace AA.CommoditiesDashboard.BDD.Tests.Steps
{
    [Binding]
    public class GetHistoricalDataStepDefinitions
    {
        private const string BASE_URL = "http://localhost:5000/api/";
        private const string API_URL = "Commodities/historicaldata";
        private RestResponse response;
        private Helper helper = new Helper();
        private RestClient client;
        [Given(@"\[User request historical data]")]
        public void GivenUserRequestHistoricalData()
        {
            client = helper.SetUrl(BASE_URL, API_URL);
        }

        [When(@"\[I send get hisotrical data]")]
        public async Task WhenISendGetHisotricalDataAsync()
        {
            var request = helper.CreateGetRequest();
            response = await helper.GetResponseAsync(client, request);
        }

        [Then(@"\[Data is retreived from API]")]
        public void ThenDataIsRetreivedFromAPI()
        {
            var content = HandleContent.GetContent<List<HistoricalDataResponse>>(response);
            Assert.IsNotNull(content);
        }
    }
}
