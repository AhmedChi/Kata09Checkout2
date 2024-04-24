using KataCheckoutBusinessLogic;

namespace KataCheckoutTests
{
    public class CheckoutTests
    {
        private CheckOut checkout;

        [SetUp]
        public void Setup()
        {
            var productsDictionary = new Dictionary<char, int>()
            {
                {'A', 50 },
                {'B', 30 },
                {'C', 20 },
                {'D', 15 }
            };


            checkout = new CheckOut(productsDictionary);

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

        [Test]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void GivenOneItemAddedToCheckout_ThenReturnCorrectPriceAsInt(string item, int expectedPrice)
        {
            //Act
            var actualPrice = checkout.Scan(item);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        [TestCase("AB", 80)]
        public void GivenTwoItemsAddedToCheckout_ThenReturnCorrectPriceAsInt(string item, int expectedPrice)
        {
            //Act
            var actualPrice = checkout.Scan(item);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}