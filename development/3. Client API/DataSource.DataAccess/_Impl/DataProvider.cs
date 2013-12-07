using System;
using System.Collections.Generic;
using DataSource.Domain;

namespace DataSource.DataAccess._Impl
{
    public class DataProvider : IDataProvider
    {
        private readonly IRestClient _restClient;

        public DataProvider(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            var response = _restClient.Get("Restaurants");
            var json = response.Content.ReadAsStringAsync().Result;

            throw new NotImplementedException();
        }
    }
}