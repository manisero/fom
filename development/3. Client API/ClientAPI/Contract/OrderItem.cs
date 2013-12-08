using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public int DishID { get; set; }

        [DataMember]
        public int? Quantity { get; set; }

        [DataMember]
        public string Remarks { get; set; }
    }
}