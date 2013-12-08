using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ClientAPI.Contract;
using ClientAPI.Contract.Responses;

namespace ClientAPI
{
    [ServiceContract]
    public interface IClientAPIService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/restaurants")]
        List<Restaurant> GetAllRestaurants();

        [OperationContract]
        [WebGet(UriTemplate = "/restaurants/{restaurantId}/dishes")]
        List<Dish> GetRestaurantDishes(string restaurantId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/orders", Method = "POST")]
        CreateOrderResponse CreateOrder(Order order);
    }
}
