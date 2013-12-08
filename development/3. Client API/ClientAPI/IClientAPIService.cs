using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ClientAPI.Contract;

namespace ClientAPI
{
    [ServiceContract]
    public interface IClientAPIService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/restaurants")]
        List<Restaurant> GetAllRestaurants();

        [OperationContract]
        [WebInvoke(UriTemplate = "/orders", Method = "POST")]
        void CreateOrder(Order order);
    }
}
