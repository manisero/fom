using System;
using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderID { get; set; }

        [DataMember]
        public int RestaurantID { get; set; }

        [DataMember]
        public string RestaurantName { get; set; }

        [DataMember]
        public string RestaurantAddress { get; set; }

        [DataMember]
        public string RestaurantPhoneNumber { get; set; }

        [DataMember]
        public string RestaurantEmailAddress { get; set; }

        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public TimeSpan? IntendedDeliveryTime { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}