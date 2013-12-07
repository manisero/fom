using System;

namespace Domain
{
    public class Order
    {
        public Person Owner { get; set; }

        public int RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        public string RestaurantAddress { get; set; }

        public string RestaurantPhoneNumber { get; set; }

        public string RestaurantEmailAddress { get; set; }

        public DateTime DeliveryDate { get; set; }

        public TimeSpan IntendedDeliveryTime { get; set; }

        public string Status { get; set; }
    }
}
