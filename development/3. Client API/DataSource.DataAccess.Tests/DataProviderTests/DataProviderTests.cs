using System.Collections.Generic;
using Core.Serialization;
using Core.Serialization._Impl;
using DataSource.DataAccess._Impl;
using DataSource.Domain;
using Xunit;
using System.Linq;

namespace DataSource.DataAccess.Tests.DataProviderTests
{
    public class DataProviderTests : TestsBase
    {
        private IEnumerable<Restaurant> Execute()
        {
            // Arrange
            AutoMoqer.GetMock<IRestClient>().Setup(x => x.Get("Restaurants")).Returns(TestData.RestaurantsJSON);
            AutoMoqer.SetInstance<IJsonSerializer>(new JsonSerializer());

            // Act
            return AutoMoqer.Resolve<DataProvider>().GetRestaurants();
        }
        
        [Fact]
        public void deserializes_restaurants_response()
        {
            var result = Execute();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void deserializes_restaurant_fields()
        {
            var result = Execute();

            // Assert
            var restaurant = result.First();
            Assert.Equal("Hawaii Pizza", restaurant.Name);
            Assert.Equal("ul.Micha\u0142a Spisaka 44\r\n02-495 Warszawa", restaurant.Address);
            Assert.Equal("226684613", restaurant.Phone_Number);
            Assert.Equal("biuro@hawaiipizza.pl", restaurant.Email_Address);
        }
    }
}
