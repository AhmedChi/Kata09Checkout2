namespace KataCheckoutBusinessLogic
{
    public interface ICheckOut
    {
        int Scan(string scannedItem);

        int GetTotalPrice(List<char> scannedItems);
    }
}