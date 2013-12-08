namespace Domain
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Order Order { get; set; }

        public decimal Amount { get; set; }
    }
}
