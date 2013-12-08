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
            var restaurant = _dataProvider.GetRestaurant(int.Parse(restaurantId));

            return restaurant.Dishes.MapToCollection<Dish>().ToList();
        }

        public CreateOrderResponse CreateOrder(Order order)
        {
            var newOrder = _orderService.CreateOrder(order.RestaurantID,
                                                     order.DeliveryDate.MapTo<DateTime?>(),
                                                     order.IntendedDeliveryTime.MapTo<TimeSpan?>());

            return new CreateOrderResponse { OrderID = newOrder.OrderID };
        }
    }
}