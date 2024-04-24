namespace KataCheckoutBusinessLogic
{
    public class CheckOut : ICheckOut
    {
        private readonly IEnumerable<IItem> _items;

        private char[] scannedItems;

        public CheckOut(IEnumerable<IItem> items)
        {
            _items = items;
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

            totalValue = scannedItems
                        .Select(sku => _items.FirstOrDefault(item => item.SKU == sku))
                        .Sum(product => product.Price);

            return totalValue;
        }
    }
}