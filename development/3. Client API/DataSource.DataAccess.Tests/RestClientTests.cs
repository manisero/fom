using System;
using DataSource.DataAccess._Impl;
using Xunit;

namespace DataSource.DataAccess.Tests
{
    public class RestClientTests
    {
        [Fact]
        public void hits_data_source_service()
        {
            // Act
            var result = new RestClient().Get("restaurants");

            // Assert
            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public void gets_restaurants_response()
        {
            // Act
            var result = new RestClient().Get("restaurants");

            // Assert
            var content = result.Content.ReadAsStringAsync().Result;
            Assert.False(string.IsNullOrWhiteSpace(content));

            Console.WriteLine(content);
        }
    }
}
