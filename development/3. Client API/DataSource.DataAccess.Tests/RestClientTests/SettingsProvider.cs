namespace DataSource.DataAccess.Tests.RestClientTests
{
    public class SettingsProvider : IDataAccessSettingsProvider
    {
        public string DataSourceAddress
        {
            get { return @"http://192.168.1.147:8080/api/"; }
        }
    }
}