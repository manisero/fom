namespace Domain
{
    public class Payment
    {
        public Person Person { get; set; }

        public Order Order { get; set; }

        public decimal Amount { get; set; }
    }
}
