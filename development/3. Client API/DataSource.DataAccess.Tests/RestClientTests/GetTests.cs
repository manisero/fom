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
            // Act
            var result = new RestClient(new SettingsProvider()).Get("restaurants");

            // Assert
            var content = result.Content.ReadAsStringAsync().Result;
            Assert.False(string.IsNullOrWhiteSpace(content));

            Console.WriteLine(content);
        }
    }
}
