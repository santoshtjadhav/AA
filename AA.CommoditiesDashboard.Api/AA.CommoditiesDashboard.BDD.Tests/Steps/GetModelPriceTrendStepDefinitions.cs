using AA.CommoditiesDashboard.ApplicationService.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace AA.CommoditiesDashboard.BDD.Tests.Steps
{
    [Binding]
    public class GetModelPriceTrendStepDefinitions
    {
        private const string BASE_URL = "http://localhost:5000/api/";
        private const string API_URL = "Commodities/modelpricetrend";
        private RestResponse response;
        private Helper helper = new Helper();
        private RestClient client;
        [Given(@"\[User request GetModelPriceTrend data]")]
        public void GivenUserRequestGetModelPriceTrendData()
        {
            client = helper.SetUrl(BASE_URL, API_URL);
        }

        [When(@"\[I send get GetModelPriceTrend data]")]
        public async Task WhenISendGetGetModelPriceTrendData()
        {
            var request = helper.CreateGetRequest();
            response = await helper.GetResponseAsync(client, request);
        }
        [Then(@"\[Data ModelPriceTrend is retreived from API]")]
        public void ThenDataModelPriceTrendIsRetreivedFromAPI()
        {
            var content = HandleContent.GetContent<List<ModelPriceTrendResponse>>(response);
            Assert.IsNotNull(content);
        }

    }
}
