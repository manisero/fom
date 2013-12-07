using DataSource.DataAccess._Impl;
using Xunit;

namespace DataSource.DataAccess.Tests.RestClientTests
{
    public class ConnectivityTests
    {
        [Fact]
        public void should_hit_default_data_source_service()
        {
            // Arrange
            var restClient = new RestClient(new SettingsProvider());

            // Act
            Assert.DoesNotThrow(() => restClient.Get("restaurants"));
        }   
    }
}