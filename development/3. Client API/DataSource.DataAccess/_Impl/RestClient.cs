using System;
using System.Net.Http;

namespace DataSource.DataAccess._Impl
{
    public class RestClient : IRestClient
    {
        private readonly IDataAccessSettingsProvider _settingsProvider;

        private HttpClient _httpClient;
        private HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri(_settingsProvider.DataSourceAddress);
                }

                return _httpClient;
            }
        }

        public RestClient(IDataAccessSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public HttpResponseMessage Get(string resource)
        {
            return HttpClient.GetAsync(resource).Result;
        }
    }
}