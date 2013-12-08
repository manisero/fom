namespace Domain
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        public virtual Order Order { get; set; }

        public virtual Person Owner { get; set; }

        public string DishName { get; set; }

        public decimal DishPrice { get; set; }

        public int Quantity { get; set; }

        public string Remarks { get; set; }

        public bool Accepted { get; set; }
    }
}
