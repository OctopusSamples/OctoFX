using System;
using NUnit.Framework;
using OctoFX.Core.Model;

namespace OctoFX.Tests.OctoFX.Core.Model
{
    [TestFixture]
    public class CurrencyTests
    {
        [Test]
        [TestCase("AUD", "AUD", "Australian Dollar")]
        [TestCase("EUR", "EUR", "Euro")]
        [TestCase("GBP", "GBP", "British Pound")]
        [TestCase("gbp", "GBP", "British Pound")]
        [TestCase("USD", "USD", "United States Dollar")]
        [TestCase("Usd", "USD", "United States Dollar")]
        public void ShouldFindByCurrencyCode(string find, string expectedIsoCode, string expectedDisplayName)
        {
            var found = Currency.FromIsoCode(find);
            Assert.That(found.IsoCurrencyCode, Is.EqualTo(expectedIsoCode));
            Assert.That(found.DisplayName, Is.EqualTo(expectedDisplayName));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(" USD")]
        [TestCase("USD  ")]
        [TestCase("CAD")]
        public void ShouldThrowWhenUnsupported(string find)
        {
            Assert.Throws<NotSupportedException>(() => Currency.FromIsoCode(find));
        }

        [Test]
        public void ShouldBeEqual()
        {
            var a = Currency.Usd;
            var b = Currency.FromIsoCode("USD");
            Assert.That(a, Is.EqualTo(b));
            Assert.That(a == b, Is.True);
            Assert.That(a != b, Is.False);
            Assert.That(a.GetHashCode() == b.GetHashCode(), Is.True);
        }

        [Test]
        public void ShouldNotBeEqual()
        {
            var a = Currency.Usd;
            var b = Currency.FromIsoCode("GBP");
            Assert.That(a, Is.Not.EqualTo(b));
            Assert.That(a == b, Is.False);
            Assert.That(a != b, Is.True);
            Assert.That(a.GetHashCode() == b.GetHashCode(), Is.False);
        }

        [Test]
        public void CanConvert()
        {
            var currency = Currency.Usd;
            string s = currency;
            Currency currency2 = s;

            Assert.AreEqual(currency, currency2);
        }
    }
}
