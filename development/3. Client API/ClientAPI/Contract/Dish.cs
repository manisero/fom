using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class Dish
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}