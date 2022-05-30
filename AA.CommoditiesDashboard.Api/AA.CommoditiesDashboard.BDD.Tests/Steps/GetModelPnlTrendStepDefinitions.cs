using AA.CommoditiesDashboard.ApplicationService.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace AA.CommoditiesDashboard.BDD.Tests.Steps
{
    [Binding]
    public class GetModelPnlTrendStepDefinitions
    {
        private const string BASE_URL = "http://localhost:5000/api/";
        private const string API_URL = "Commodities/modelpnltrend";
        private RestResponse response;
        private Helper helper = new Helper();
        private RestClient client;
        [Given(@"\[User request ModelPnlTrend data]")]
        public void GivenUserRequestModelPnlTrendData()
        {
            client = helper.SetUrl(BASE_URL, API_URL);
        }

        [When(@"\[I send get ModelPnlTrend data]")]
        public async Task WhenISendGetModelPnlTrendData()
        {
            var request = helper.CreateGetRequest();
            response = await helper.GetResponseAsync(client, request);
        }
        [Then(@"\[Data ModelPnlTrend is retreived from API]")]
        public void ThenDataModelPnlTrendIsRetreivedFromAPI()
        {
            var content = HandleContent.GetContent<List<ModelPnlTrendResponse>>(response);
            Assert.IsNotNull(content);
        }

    }
}
