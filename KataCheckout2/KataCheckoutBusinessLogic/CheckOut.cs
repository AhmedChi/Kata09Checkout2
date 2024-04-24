namespace KataCheckoutBusinessLogic
{
    public class CheckOut
    {
        private Dictionary<char, int> _productDictionary;

        public CheckOut(Dictionary<char, int> productDictionary)
        {
            _productDictionary = productDictionary;
        }

        public int Scan(string scannedItem)
        {
            var totalPrice = 0;

            if (!String.IsNullOrEmpty(scannedItem))
            {
               for (int index = 0; index < scannedItem.Length; index++)
               {
                    if (_productDictionary.ContainsKey(scannedItem[index]))
                    {
                        totalPrice += _productDictionary[scannedItem[index]];

                        
                    }
               }

                return totalPrice;
            }

            return 0;
        }
    }
}