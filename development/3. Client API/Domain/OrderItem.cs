namespace Domain
{
    public class OrderItem
    {
        public Order Order { get; set; }

        public Person Person { get; set; }

        public string DishName { get; set; }

        public decimal DishPrice { get; set; }

        public int Quantity { get; set; }
    }
}
