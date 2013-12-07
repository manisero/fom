using System;
using DataSource.DataAccess._Impl;
using Xunit;

namespace DataSource.DataAccess.Tests.RestClientTests
{
    public class GetTests
    {
        [Fact]
        public void should_receive_restaurants_response()
        {
            // Arrange
            var restClient = new RestClient(new SettingsProvider());

            // Act
            var result = restClient.Get("restaurants");

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(result));

            Console.WriteLine(result);
        }
    }
}
