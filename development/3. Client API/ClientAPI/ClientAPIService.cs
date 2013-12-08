using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ClientAPI.Contract;
using ClientAPI.Contract.Responses;
using DataSource.DataAccess;
using ClientAPI.AutoMapper.Extensions;
using System.Linq;
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

        public List<Order> GetAllOrders()
        {
            return _orderService.GetOrders().MapToCollection<Order>().ToList();
        }

        public CreateOrderResponse CreateUserOrder(string userName, Order order)
        {
            var newOrder = _orderService.CreateOrder(userName, order.RestaurantID, order.MapTo<OrderInfo>());

            return new CreateOrderResponse { OrderID = newOrder.OrderID };
        }

        public void CreateOrderItems(string orderId, IEnumerable<OrderItem> orderItems)
        {
            _orderService.CreateOrderItems(orderId.ToInt(), orderItems.MapToCollection<OrderItemInfo>());
        }
    }
}