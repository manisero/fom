using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ClientAPI.Contract;
using ClientAPI.Contract.Responses;
using DataSource.DataAccess;
using ClientAPI.AutoMapper.Extensions;
using System.Linq;
using Domain;
using Logic.DataManagement;
using Logic.DataManagement.Model;
using Core.Extensions;

namespace ClientAPI
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ClientAPIService : IClientAPIService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IOrderService _orderService;

        public ClientAPIService(IDataProvider dataProvider, IOrderService orderService)
        {
            _dataProvider = dataProvider;
            _orderService = orderService;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _dataProvider.GetRestaurants().MapToCollection<Restaurant>().ToList();
        }

        public List<Dish> GetRestaurantDishes(string restaurantId)
        {
            var restaurant = _dataProvider.GetRestaurant(restaurantId.ToInt());

            return restaurant.Dishes.MapToCollection<Dish>().ToList();
        }

        public List<Contract.Order> GetAllOrders()
        {
            return _orderService.GetOrders().MapToCollection<Contract.Order>().ToList();
        }

        public List<Contract.Order> GetOrdersByStatus(string status)
        {
            return _orderService.GetOrdersByStatus(status.ToEnum<OrderStatus>()).MapToCollection<Contract.Order>().ToList();
        }

        public List<Contract.Payment> SettleOrder(string orderId)
        {
            return _orderService.SettleOrder(orderId.ToInt()).MapToCollection<Contract.Payment>().ToList();
        }

        public List<Contract.Order> GetUserActiveOrders(string userName)
        {
            return _orderService.GetUserOrdersByStatuses(userName, OrderStatus.Open, OrderStatus.Settled).MapToCollection<Contract.Order>().ToList();
        }

        public CreateOrderResponse CreateUserOrder(string userName, Contract.Order order)
        {
            var newOrder = _orderService.CreateOrder(userName, order.RestaurantID, order.MapTo<OrderInfo>());

            return new CreateOrderResponse { OrderID = newOrder.OrderID };
        }

        public void CreateOrderItems(string userName, string orderId, IEnumerable<Contract.OrderItem> orderItems)
        {
            _orderService.CreateOrderItems(userName, orderId.ToInt(), orderItems.MapToCollection<OrderItemInfo>());
        }
    }
}