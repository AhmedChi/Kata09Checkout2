using KataCheckoutBusinessLogic;

namespace KataCheckoutTests
{
    public class CheckoutTests
    {
        private CheckOut checkout;

        [SetUp]
        public void Setup()
        {      

            checkout = new CheckOut();

        }

        [Test]
        public void GivenNoItemsAddedToCheckout_ThenReturnZeroAsInt()
        {
            //Arrange
            var expectedPrice = 0;

            //Act
            var actualPrice = checkout.Scan("");

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}