using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class Payment
    {
        [DataMember]
        public Person Person { get; set; }

        [DataMember]
        public decimal Amount { get; set; }
    }
}