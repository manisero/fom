using System;
using System.Linq;
using Core.Extensions;
using DataAccess.Repository;
using DataSource.DataAccess;
using Domain;

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

        public Order CreateOrder(int restaurantId, DateTime? deliveryDate, TimeSpan? intendedDeliveryTime)
        {
            // TODO: Retrieve order owner
            var owner = _repositoryFactory.Create<Person>().GetAll().FirstOrDefault();

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
                    DeliveryDate = deliveryDate ?? DateTime.UtcNow,
                    IntendedDeliveryTime = intendedDeliveryTime
                };

            _repositoryFactory.Create<Order>().Add(order);
            _unitOfWork.SaveChanges();

            return order;
        }
    }
}