using System.Runtime.Serialization;

namespace ClientAPI.Contract.Responses
{
    [DataContract]
    public class CreateOrderResponse
    {
        [DataMember]
        public int OrderID { get; set; }
    }
}