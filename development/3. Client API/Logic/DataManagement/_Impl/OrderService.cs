using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using DataAccess.Repository;
using DataSource.DataAccess;
using Domain;
using Logic.DataManagement.Model;

namespace Logic.DataManagement._Impl
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProvider _dataProvider;

        public OrderService(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork, IDataProvider dataProvider)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
            _dataProvider = dataProvider;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _repositoryFactory.Create<Order>().GetAll();
        }

        public IEnumerable<Order> GetOrdersByStatus(OrderStatus status)
        {
            return _repositoryFactory.Create<Order>().GetWhere(x => x.Status == status);
        }

        public Order CreateOrder(string ownerName, int restaurantId, OrderInfo orderInfo)
        {
            var owner = _repositoryFactory.Create<Person>().GetSingleOrDefault(x => x.Name == ownerName);

            if (owner == null)
            {
                throw new InvalidOperationException("Could not find Order owner");
            }

            var restaurant = _dataProvider.GetRestaurant(restaurantId);

            if (restaurant == null)
            {
                throw new InvalidOperationException("Restaurant of ID '{0}' does not exist".FormatWith(restaurantId));
            }

            var order = new Order
                {
                    Owner = owner,
                    RestaurantID = restaurantId,
                    RestaurantName = restaurant.Name,
                    RestaurantAddress = restaurant.Address,
                    RestaurantPhoneNumber = restaurant.Phone_Number,
                    RestaurantEmailAddress = restaurant.Email_Address,
                    DeliveryDate = orderInfo.DeliveryDate ?? DateTime.UtcNow,
                    IntendedDeliveryTime = orderInfo.IntendedDeliveryTime
                };

            _repositoryFactory.Create<Order>().Add(order);
            _unitOfWork.SaveChanges();

            return order;
        }

        public void CreateOrderItems(string ownerName, int orderId, IEnumerable<OrderItemInfo> orderItemInfos)
        {
            var owner = _repositoryFactory.Create<Person>().GetSingleOrDefault(x => x.Name == ownerName);

            if (owner == null)
            {
                throw new InvalidOperationException("Could not find Order owner");
            }

            var order = _repositoryFactory.Create<Order>().GetSingleOrDefault(x => x.OrderID == orderId);

            if (order == null)
            {
                throw new InvalidOperationException("Order of ID '{0}' does not exist".FormatWith(orderId));
            }

            var restaurant = _dataProvider.GetRestaurant(order.RestaurantID);

            foreach (var item in orderItemInfos)
            {
                var dish = restaurant.Dishes.SingleOrDefault(x => x.Dish_ID == item.DishID);

                if (dish == null)
                {
                    throw new InvalidOperationException("Dish of ID '{0}' does not exist".FormatWith(orderId));
                }

                order.OrderItems.Add(new OrderItem
                    {
                        Owner = owner,
                        DishName = dish.Name,
                        DishPrice = dish.Price,
                        Quantity = item.Quantity ?? 1,
                        Remarks = item.Remarks
                    });
            }

            _unitOfWork.SaveChanges();
        }
    }
}