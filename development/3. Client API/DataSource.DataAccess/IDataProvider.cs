using System.Collections.Generic;
using DataSource.Domain;

namespace DataSource.DataAccess
{
    public interface IDataProvider
    {
        IEnumerable<Restaurant> GetRestaurants();
    }
}
