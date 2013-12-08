using System;

namespace Logic.DataManagement.Model
{
    public class OrderInfo
    {
        public DateTime? DeliveryDate { get; set; }

        public TimeSpan? IntendedDeliveryTime { get; set; }
    }
}
