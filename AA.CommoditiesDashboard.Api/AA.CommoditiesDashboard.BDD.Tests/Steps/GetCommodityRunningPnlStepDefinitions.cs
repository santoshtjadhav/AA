using AA.CommoditiesDashboard.ApplicationService.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace AA.CommoditiesDashboard.BDD.Tests.Steps
{
    [Binding]
    public class GetCommodityRunningPnlStepDefinitions
    {
        private const string BASE_URL = "http://localhost:5000/api/";
        private const string API_URL = "Commodities/runningcommodity";
        private RestResponse response;
        private Helper helper = new Helper();
        private RestClient client;

        [Given(@"\[User request commodity data]")]
        public async Task GivenUserRequestCommodityData()
        {
            client = helper.SetUrl(BASE_URL, API_URL);
        }

        [When(@"\[I send get commodity data]")]
        public async Task WhenISendGetCommodityData()
        {
            var request = helper.CreateGetRequest();
            response = await helper.GetResponseAsync(client, request);
        }

        [Then(@"\[Data commodity is retreived from API]")]
        public void ThenDataCommodityIsRetreivedFromAPI()
        {
            var content = HandleContent.GetContent<List<CommodityRunningPnlResponse>>(response);
            Assert.IsNotNull(content);
        }

    }
}
