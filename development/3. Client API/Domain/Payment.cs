namespace Domain
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public Person Person { get; set; }

        public Order Order { get; set; }

        public decimal Amount { get; set; }
    }
}
