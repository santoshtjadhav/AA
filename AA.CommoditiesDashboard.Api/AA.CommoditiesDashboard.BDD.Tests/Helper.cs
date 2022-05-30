using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.BDD.Tests
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;
        private X509Certificate2 certificate;


        public void AddCertificate(string certPath, string certFileName)
        {
            var certFile = Path.Combine(certPath, certFileName);
            certificate = new X509Certificate2(certFile);
        }

        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }

            });
            return request;
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePutRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Put
            };
            request.AddHeader("Accept", "application/json");
            //request.AddParameter("application/json", payload, ParameterType.RequestBody);
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Delete
            };
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }
    }
    public static class HandleContent
    {
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static string SerializeJsonString(dynamic content)
        {
            return JsonConvert.SerializeObject(content, Formatting.Indented);
        }

        public static T ParseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}