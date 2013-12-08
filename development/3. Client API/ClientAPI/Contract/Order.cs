using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderID { get; set; }

        [DataMember]
        public Person Owner { get; set; }

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
        public string DeliveryDate { get; set; }

        [DataMember]
        public string IntendedDeliveryTime { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}