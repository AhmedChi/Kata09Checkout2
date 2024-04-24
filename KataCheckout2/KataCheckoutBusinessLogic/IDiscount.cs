namespace KataCheckoutBusinessLogic
{
    public interface IDiscount
    {
        int DiscountAmount { get; set; }
        int QuantityAmount { get; set; }
        char SKU { get; set; }
    }
}