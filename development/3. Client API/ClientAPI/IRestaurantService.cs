using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ClientAPI.Contract;

namespace ClientAPI
{
    [ServiceContract]
    public interface IRestaurantService
    {
        [OperationContract]
        [WebGet(UriTemplate = "")]
        List<Restaurant> GetAllRestaurants();
    }
}
