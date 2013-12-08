using System.Collections.Generic;

namespace Domain
{
    public class Person
    {
        public int PersonID { get; set; }

        public string Name { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }

        public virtual IList<Payment> Payments { get; set; }
    }
}
