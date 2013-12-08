using System.Collections.Generic;
using Core.Serialization;
using DataSource.Domain;
using Core.Extensions;

namespace DataSource.DataAccess._Impl
{
    public class DataProvider : IDataProvider
    {
        private readonly IRestClient _restClient;
        private readonly IJsonSerializer _jsonSerializer;

        public DataProvider(IRestClient restClient, IJsonSerializer jsonSerializer)
        {
            _restClient = restClient;
            _jsonSerializer = jsonSerializer;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            var response = _restClient.Get("restaurants");

            return _jsonSerializer.Deserialize<IEnumerable<Restaurant>>(response);
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            var response = _restClient.Get("restaurants/{0}".FormatWith(restaurantId));

            return _jsonSerializer.Deserialize<Restaurant>(response);
        }
    }
}