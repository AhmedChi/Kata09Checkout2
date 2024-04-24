namespace KataCheckoutBusinessLogic
{
    public class CheckOut : ICheckOut
    {
        private readonly IEnumerable<IItem> _items;
        private readonly IEnumerable<IDiscount> _discounts;

        private char[] scannedItems;

        public CheckOut(IEnumerable<IItem> items, IEnumerable<IDiscount> discounts)
        {
            _items = items;
            _discounts = discounts;

            scannedItems = new char[] { };
        }

        public int Scan(string scannedItem)
        {
            if (!String.IsNullOrEmpty(scannedItem))
            {
                scannedItems = scannedItem
                    .ToCharArray()
                    .Where(sKU => _items.Any(item => item.SKU == sKU))
                    .ToArray<char>();

                return GetTotalPrice(scannedItems);
            }

            return 0;
        }

        public int GetTotalPrice(char[] scannedItems)
        {
            var totalValue = 0;
            var totalDiscount = 0;
            

            totalValue = scannedItems
                        .Select(sku => _items.FirstOrDefault(item => item.SKU == sku))
                        .Sum(product => product.Price);

            totalDiscount = _discounts
                        .Where(discount => scannedItems.Count(sku => sku == discount.SKU) >= discount.QuantityAmount)
                        .Sum(discount => discount.DiscountAmount);


            return totalValue - totalDiscount;
        }
    }
}