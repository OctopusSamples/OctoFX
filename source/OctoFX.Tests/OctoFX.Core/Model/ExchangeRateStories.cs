using NUnit.Framework;
using OctoFX.Core.Model;
using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

namespace OctoFX.Tests.OctoFX.Core.Model
{
    [Story(
        AsA = "As an account holder",
        IWant = "I want to sell currency I no longer need in exchange for a currency that I do need",
        SoThat = "So that I can make transactions in that currency")]
    public class ExchangeRateStories
    {
        private ExchangeRate exchangeRate;
        private decimal quoted;

        [Test]
        public void Selling()
        {
            this.Given(s => s.GivenARateOf(Currency.Aud, Currency.Usd, 0.9301M))
                .When(s => s.WhenIWantToSell(1000M, Currency.Aud))
                .Then(s => s.ThenIWillBeOfferred(930.10M, Currency.Usd))
                .BDDfy();
        }

        [Test]
        public void Buying()
        {
            this.Given(s => s.GivenARateOf(Currency.Aud, Currency.Usd, 0.9301M))
                .When(s => s.WhenIWantToBuy(1000M, Currency.Aud))
                .Then(s => s.ThenIWillBeOfferred(1075.1532M, Currency.Usd))
                .BDDfy();
        }

        private void GivenARateOf(Currency sell, Currency buy, decimal rate)
        {
            exchangeRate = new ExchangeRate(new CurrencyPair(sell, buy), rate);
        }

        private void WhenIWantToSell(decimal quantity, Currency currency)
        {
            quoted = exchangeRate.QuoteWhenIntendingToSell(quantity);
        }

        private void WhenIWantToBuy(decimal quantity, Currency currency)
        {
            quoted = exchangeRate.QuoteWhenIntendingToBuy(quantity);
        }

        private void ThenIWillBeOfferred(decimal quantityExpected, Currency currency)
        {
            Assert.That(quoted.ToString("n4"), Is.EqualTo(quantityExpected.ToString("n4")));
        }
    }
}