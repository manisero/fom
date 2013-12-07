using System.Collections.Generic;
using System.ServiceModel;
using ClientAPI.Contract;

namespace ClientAPI
{
    [ServiceContract]
    public interface IClientAPIService
    {
        List<Restaurant> GetAllRestaurants();
    }
}
