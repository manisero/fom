using System;
using Domain;

namespace Logic.DataManagement
{
    public interface IOrderService
    {
        Order CreateOrder(int restaurantId, DateTime? deliveryDate, TimeSpan? intendedDeliveryTime);
    }
}
