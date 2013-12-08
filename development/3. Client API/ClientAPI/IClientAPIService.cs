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
        [WebInvoke(UriTemplate = "users/{userName}/orders", Method = "POST")]
        CreateOrderResponse CreateUserOrder(string userName, Order order);

        [OperationContract]
        [WebGet(UriTemplate = "/orders")]
        List<Order> GetAllOrders();

        [OperationContract]
        [WebInvoke(UriTemplate = "/orders/{orderId}/items", Method = "PUT")]
        void CreateOrderItems(string orderId, IEnumerable<OrderItem> orderItems);
    }
}
