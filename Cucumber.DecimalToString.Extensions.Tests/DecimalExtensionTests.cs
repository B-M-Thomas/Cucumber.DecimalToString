using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cucumber.DecimalToString.Extensions;

namespace Cucumber.DecimalToString.Extensions.Tests
{
    [TestClass]
    public class DecimalExtensionTests
    {

        [TestMethod]
        public void Should_OnlyIncludeCents_When_InputIsBetweenZeroAndOne()
        {
            var input = 0.25m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("TWENTY FIVE CENTS", result);
        }

        [TestMethod]
        public void Should_OnlyIncludeDollars_When_InputHasNoDecimalPlaces()
        {
            var input = 100m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("ONE HUNDRED DOLLARS", result);
        }

        [TestMethod]
        public void Should_ReadDollarsAndCents_When_InputHasWholeAndFractionalNumbers()
        {
            var input = 10000.42m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("TEN THOUSAND DOLLARS AND FORTY TWO CENTS", result);
        }

        [TestMethod]
        public void Should_ReadCent_When_InputHasSingleCent()
        {
            var input = 0.01m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("ONE CENT", result);
        }

        [TestMethod]
        public void Should_OutputNothing_When_InputIsZero()
        {
            var input = 0.00m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Should_OutputCentsOnly_When_InputIsBetweenOneAndMinusOne()
        {
            var input = 0.62m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("SIXTY TWO CENTS", result);
        }

        [TestMethod]
        public void Should_ReadBillions_When_InputHasGreaterThanABillion()
        {
            var input = 111111111111.00m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("ONE HUNDRED AND ELEVEN BILLION ONE HUNDRED AND ELEVEN MILLION ONE HUNDRED AND ELEVEN THOUSAND ONE HUNDRED AND ELEVEN DOLLARS", result);
        }

        [TestMethod]
        public void Should_ReadAndBetween_When_InputIsGreaterThan10ButLessThanTwenty()
        {
            var input = 19m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("NINETEEN DOLLARS", result);
        }

        [TestMethod]
        public void Should_ReadMinus_When_InputIsNegative()
        {
            var input = -1m;

            var result = input.ToStringRepresentation();

            Assert.AreEqual("MINUS ONE DOLLAR", result);
        }
    }
}
