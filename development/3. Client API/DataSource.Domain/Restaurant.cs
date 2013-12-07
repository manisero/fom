using System.Collections.Generic;

namespace DataSource.Domain
{
    public class Restaurant
    {
        public int Restaurant_ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone_Number { get; set; }

        public string Email_Address { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
    }
}
