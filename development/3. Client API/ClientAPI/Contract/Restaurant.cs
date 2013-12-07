using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public int RestaurantID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}