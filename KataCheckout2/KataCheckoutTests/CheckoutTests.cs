using KataCheckoutBusinessLogic;

namespace KataCheckoutTests
{
    public class CheckoutTests
    {
        private ICheckOut checkout;

        [SetUp]
        public void Setup()
        {

            var products = new[]
            {
                new Item{ SKU = 'A', Price = 50 },
                new Item{ SKU = 'B', Price = 30 },
                new Item{ SKU = 'C', Price = 20 },
                new Item{ SKU = 'D', Price = 15 }
            };


            checkout = new CheckOut(products);

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
        [TestCase("AC", 70)]
        [TestCase("AD", 65)]
        [TestCase("BC", 50)]
        [TestCase("BD", 45)]
        [TestCase("CD", 35)]
        public void GivenTwoItemsAddedToCheckout_ThenReturnCorrectPriceAsInt(string item, int expectedPrice)
        {
            //Act
            var actualPrice = checkout.Scan(item);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        [TestCase("CDBA", 115)]
        public void GivenFourItemsAddedToCheckout_ThenReturnCorrectPriceAsInt(string item, int expectedPrice)
        {
            //Act
            var actualPrice = checkout.Scan(item);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [Test]
        [TestCase("AA", 100)]
        public void GivenTwoDuplicateItemsAddedToCheckout_ThenReturnCorrectPriceAsInt(string item, int expectedPrice)
        {
            //Act
            var actualPrice = checkout.Scan(item);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        [TestCase("AAA", 130)]
        public void GivenThreeDuplicateItemsAddedToCheckout_ThenReturnCorrectPriceAsInt(string item, int expectedPrice)
        {
            //Act
            var actualPrice = checkout.Scan(item);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}