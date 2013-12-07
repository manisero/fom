using Core.Serialization._Impl;
using DataSource.DataAccess._Impl;
using Xunit;

namespace DataSource.DataAccess.Tests.DataProviderTests
{
    public class DataProviderTests
    {
        private class RestClient : IRestClient
        {
            private readonly string _response;

            public RestClient(string response)
            {
                _response = response;
            }

            public string Get(string resource)
            {
                return _response;
            }
        }

        [Fact]
        public void deserializes_restaurants_response()
        {
            // Arrange
            var dataProvider = new DataProvider(new RestClient(TestData.RestaurantsJSON), new JsonSerializer());

            // Act
            var result = dataProvider.GetRestaurants();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
