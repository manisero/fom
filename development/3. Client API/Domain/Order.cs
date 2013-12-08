using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public int OrderID { get; set; }

        public virtual Person Owner { get; set; }

        public int RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        public string RestaurantAddress { get; set; }

        public string RestaurantPhoneNumber { get; set; }

        public string RestaurantEmailAddress { get; set; }

        public DateTime DeliveryDate { get; set; }

        public TimeSpan? IntendedDeliveryTime { get; set; }

        public string Status { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }
    }
}
