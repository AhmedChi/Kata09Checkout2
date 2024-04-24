namespace KataCheckoutBusinessLogic
{
    public class Discount : IDiscount
    {
        public char SKU { get; set; }
        public int QuantityAmount { get; set; }
        public int DiscountAmount { get; set; }
    }
}
