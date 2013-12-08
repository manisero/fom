using System.Runtime.Serialization;

namespace ClientAPI.Contract
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
    }
}