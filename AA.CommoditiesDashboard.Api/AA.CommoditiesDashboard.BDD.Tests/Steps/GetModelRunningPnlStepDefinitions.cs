using AA.CommoditiesDashboard.ApplicationService.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace AA.CommoditiesDashboard.BDD.Tests.Steps
{
    [Binding]
    public class GetModelRunningPnlStepDefinitions
    {
        private const string BASE_URL = "http://localhost:5000/api/";
        private const string API_URL = "Commodities/runningmodel";
        private RestResponse response;
        private Helper helper = new Helper();
        private RestClient client;
        [Given(@"\[User request ModelRunningPnl data]")]
        public void GivenUserRequestModelRunningPnlData()
        {
            client = helper.SetUrl(BASE_URL, API_URL);
        }

        [When(@"\[I send get ModelRunningPnl data]")]
        public async Task WhenISendGetModelRunningPnlData()
        {
            var request = helper.CreateGetRequest();
            response = await helper.GetResponseAsync(client, request);
        }

        [Then(@"\[Data ModelRunningPnl is retreived from API]")]
        public void ThenDataModelRunningPnlIsRetreivedFromAPI()
        {
            var content = HandleContent.GetContent<List<ModelRunningPnlResponse>>(response);
            Assert.IsNotNull(content);
        }

    }
}
