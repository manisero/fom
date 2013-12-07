using System.Net.Http;

namespace DataSource.DataAccess
{
    public interface IRestClient
    {
        HttpResponseMessage Get(string resource);
    }
}
