﻿using System.Collections.Generic;
using Domain;
using Logic.DataManagement.Model;

namespace Logic.DataManagement
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();

        IEnumerable<Order> GetOrdersByStatus(OrderStatus status);
            
        Order CreateOrder(string ownerName, int restaurantId, OrderInfo orderInfo);

        void CreateOrderItems(string ownerName, int orderId, IEnumerable<OrderItemInfo> orderItemInfos);
    }
}
