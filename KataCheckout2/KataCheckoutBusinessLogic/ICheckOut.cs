namespace KataCheckoutBusinessLogic
{
    public interface ICheckOut
    {
        int Scan(string scannedItem);

        int GetTotalPrice(char[] scannedItems);
    }
}