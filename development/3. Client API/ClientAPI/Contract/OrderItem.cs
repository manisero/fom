using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public string DishName { get; set; }

        [DataMember]
        public decimal DishPrice { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Remarks { get; set; }
    }
}