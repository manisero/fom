using DataSource.DataAccess._Impl;
using Xunit;

namespace DataSource.DataAccess.Tests.RestClientTests
{
    public class ConnectivityTests
    {
        [Fact]
        public void should_hit_default_data_source_service()
        {
            // Act
            var result = new RestClient(new SettingsProvider()).Get("restaurants");

            // Assert
            Assert.True(result.IsSuccessStatusCode);
        }   
    }
}