using System.Collections.Generic;
using Core.Serialization;
using Core.Serialization._Impl;
using DataSource.DataAccess._Impl;
using DataSource.Domain;
using Xunit;
using System.Linq;

namespace DataSource.DataAccess.Tests.DataProviderTests
{
    public class GetRestaurantsTests : TestsBase
    {
        private IEnumerable<Restaurant> Execute()
        {
            // Arrange
            AutoMoqer.GetMock<IRestClient>().Setup(x => x.Get("restaurants")).Returns(TestData.RestaurantsJSON);
            AutoMoqer.SetInstance<IJsonSerializer>(new JsonSerializer());

            // Act
            return AutoMoqer.Resolve<DataProvider>().GetRestaurants();
        }
        
        [Fact]
        public void deserializes_restaurants_response()
        {
            var result = Execute();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void deserializes_restaurant_fields()
        {
            var result = Execute();

            // Assert
            var restaurant = result.First();
            Assert.Equal(1, restaurant.Restaurant_ID);
            Assert.Equal("Hawaii Pizza", restaurant.Name);
            Assert.Equal("ul.Micha\u0142a Spisaka 44\r\n02-495 Warszawa", restaurant.Address);
            Assert.Equal("226684613", restaurant.Phone_Number);
            Assert.Equal("biuro@hawaiipizza.pl", restaurant.Email_Address);

            var dishes = restaurant.Dishes;
            Assert.NotNull(dishes);
            Assert.Equal(1, dishes.Count());

            var dish = dishes.First();
            Assert.Equal(3, dish.Dish_ID);
            Assert.Equal("Lunch dnia", dish.Name);
            Assert.Equal(15.50m, dish.Price);
            Assert.Equal("Ka\u017cdego dnia w tygodniu, w godzinach 12.00-16.00, nowa oferta lunchowa. Szczeg\u00f3\u0142y na: http://www.hawaiipizza.pl/index.php/lunch.", dish.Description);

        }
    }
}
