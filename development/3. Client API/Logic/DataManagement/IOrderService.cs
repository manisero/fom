using System.Collections.Generic;
using Domain;
using Logic.DataManagement.Model;

namespace Logic.DataManagement
{
    public interface IOrderService
    {
        Order CreateOrder(int restaurantId, OrderInfo orderInfo);

        void CreateOrderItems(int orderId, IEnumerable<OrderItemInfo> orderItemInfos);
    }
}
