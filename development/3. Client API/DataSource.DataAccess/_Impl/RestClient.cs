using System;
using System.Net.Http;

namespace DataSource.DataAccess._Impl
{
    public class RestClient : IRestClient
    {
        public HttpResponseMessage Get(string resource)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(@"http://192.168.1.147:8080/");

            return httpClient.GetAsync(resource).Result;
        }
    }
}