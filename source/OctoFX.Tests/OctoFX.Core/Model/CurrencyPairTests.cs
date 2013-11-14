using System;
using NUnit.Framework;
using OctoFX.Core.Model;

namespace OctoFX.Tests.OctoFX.Core.Model
{
    [TestFixture]
    public class CurrencyPairTests
    {
        [Test]
        public void ShouldBeUnequalWhenOrderOfCurrenciesChanges()
        {
            var pair1 = new CurrencyPair(Currency.Aud, Currency.Usd);
            var pair2 = new CurrencyPair(Currency.Aud, Currency.Usd);
            var pair3 = new CurrencyPair(Currency.Usd, Currency.Aud);
            Assert.AreEqual(pair1, pair2);
            Assert.AreNotEqual(pair2, pair3);
        }

        [Test]
        public void ShouldNotCreatePairOfSameCurrency()
        {
            Assert.Throws<ArgumentException>(() => new CurrencyPair(Currency.Aud, Currency.Aud));
        }

        [Test]
        [TestCase("USD", null)]
        [TestCase(null, "USD")]
        public void ShouldNotAllowNullPairs(string a, string b)
        {
            Assert.Throws<ArgumentNullException>(() => new CurrencyPair(a, b));
        }

        [Test]
        [TestCase("USD", "AUD", "USD/AUD")]
        [TestCase("AUD", "USD", "AUD/USD")]
        public void ShouldFormatNicely(string a, string b, string expected)
        {
            Assert.That(new CurrencyPair(a, b).ToString(), Is.EqualTo(expected));
        }

        [Test]
        [TestCase("AUD/USD", "AUD", "USD")]
        [TestCase("AUD/GBP", "AUD", "GBP")]
        [TestCase("EUR/USD", "EUR", "USD")]
        public void ShouldParse(string pair, string a, string b)
        {
            var parsed = CurrencyPair.Parse(pair);
            Assert.That(parsed.Sell, Is.EqualTo((Currency)a));
            Assert.That(parsed.Buy, Is.EqualTo((Currency)b));
        }
    }
}