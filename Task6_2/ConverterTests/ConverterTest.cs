using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task6_2;

namespace ConverterTests
{
    [TestFixture]
    public class ConverterTest
    {
        StringConverter converter;

        [OneTimeSetUp]
        public void SetUp()
        {
            converter = new StringConverter();
        }

        //tests for TryConvertToInt()
        [TestCase("123", 123)]
        [TestCase("-123", -123)]
        [TestCase("2147483647", 2147483647)]
        [TestCase("-2147483648", -2147483648)]
        [TestCase("0", 0)]
        public void TryConvertValidStringTest(string str, int number)
        {
            int actualNumber;
            converter.TryConvertToInt(str, out actualNumber);
            Assert.AreEqual(number, actualNumber);
        }

        [TestCase("1df23")]
        [TestCase("-12df3")]
        [TestCase("1.23")]
        [TestCase("1,23")]
        [TestCase("")]
        [TestCase(null)]
        public void TryConvertInvalidStringTest(string str)
        {
            int number;
            Assert.IsFalse(converter.TryConvertToInt(str, out number));
        }

        [TestCase("2200000000")]
        [TestCase("-2200000000")]
        [TestCase("32100000000")]
        [TestCase("-32100000000")]
        public void TryConvertWithOverflowTest(string str)
        {
            int number;
            Assert.IsFalse(converter.TryConvertToInt(str, out number));
        }

        //tests for ConvertToInt()
        [TestCase("123", 123)]
        [TestCase("-123", -123)]
        [TestCase("2147483647", 2147483647)]
        [TestCase("-2147483648", -2147483648)]
        [TestCase("0", 0)]
        public void ConvertValidStringTest(string str, int number)
        {
            Assert.AreEqual(number, converter.ConvertToInt(str));
        }

        [TestCase("1df23")]
        [TestCase("-12df3")]
        [TestCase("1.23")]
        [TestCase("1,23")]
        [TestCase("")]
        public void ConvertInvalidStringTest(string str)
        {
            Assert.Throws<FormatException>(() => converter.ConvertToInt(str));
        }

        [Test]
        public void ConvertNullStringTest()
        {
            Assert.Throws<ArgumentNullException>(() => converter.ConvertToInt(null));
        }

        [TestCase("2200000000")]
        [TestCase("-2200000000")]
        [TestCase("32100000000")]
        [TestCase("-32100000000")]
        public void ConvertWithOverflowTest(string str)
        {
            Assert.Throws<OverflowException>(() => converter.ConvertToInt(str));
        }
    }
}
