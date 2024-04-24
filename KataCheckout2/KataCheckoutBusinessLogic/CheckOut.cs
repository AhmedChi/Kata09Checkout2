namespace KataCheckoutBusinessLogic
{
    public class CheckOut : ICheckOut
    {
        private readonly IEnumerable<IItem> _items;
        private readonly IEnumerable<IDiscount> _discounts;

        private List<char> scannedItems;

        public CheckOut(IEnumerable<IItem> items, IEnumerable<IDiscount> discounts)
        {
            _items = items;
            _discounts = discounts;

            scannedItems = new List<char> { };
        }

        public int Scan(string scannedItem)
        {            
            if (!String.IsNullOrEmpty(scannedItem))
            {
                scannedItems
                    .AddRange(scannedItem
                    .Where(sku => _items.Any(item => item.SKU == sku)));

                if (scannedItems.Count == 0)
                {
                    return 0;
                }

                return GetTotalPrice(scannedItems);
            }

            return 0;                 
        }

        public int GetTotalPrice(List<char> scannedItems)
        {
            var totalValue = scannedItems
                        .Select(sku => _items.FirstOrDefault(item => item.SKU == sku))
                        .Sum(product => product.Price);

            var totalDiscount = _discounts
                .Select(discount =>
                {
                    var itemCount = scannedItems.Count(sku => sku == discount.SKU);

                    var discountApplications = itemCount / discount.QuantityAmount;

                    var discountTotal = discountApplications * discount.DiscountAmount;

                    return discountTotal;
                })
                .Sum();

            return totalValue - totalDiscount;
        }

    }
}