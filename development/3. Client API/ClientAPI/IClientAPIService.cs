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
        [WebGet(UriTemplate = "/orders")]
        List<Order> GetAllOrders();

        [OperationContract]
        [WebGet(UriTemplate = "/orders/{status}")]
        List<Order> GetOrdersByStatus(string status);

        [OperationContract]
        [WebInvoke(UriTemplate = "/orders/{orderId}/settle", Method = "POST")]
        List<Payment> SettleOrder(string orderId);

        [OperationContract]
        [WebGet(UriTemplate = "users/{userName}/orders")]
        List<Order> GetUserActiveOrders(string userName);

        [OperationContract]
        [WebInvoke(UriTemplate = "users/{userName}/orders", Method = "POST")]
        CreateOrderResponse CreateUserOrder(string userName, Order order);

        [OperationContract]
        [WebInvoke(UriTemplate = "users/{userName}/orders/{orderId}/items", Method = "PUT")]
        void CreateOrderItems(string userName, string orderId, IEnumerable<OrderItem> orderItems);
    }
}
