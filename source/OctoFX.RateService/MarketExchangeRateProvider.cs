using System;
using System.Collections.Generic;
using OctoFX.Core.Model;

namespace OctoFX.RateService
{
    /// <summary>
    /// Generates sample rates using a random number generator. Rates will be within +/- 0.10 
    /// of a given sample rate for the currency pair.
    /// </summary>
    public class MarketExchangeRateProvider : IMarketExchangeRateProvider
    {
        const decimal MaxVolatility = 0.20M;
        static readonly Dictionary<CurrencyPair, decimal> averageSampleRate = new Dictionary<CurrencyPair, decimal>();
        static readonly Random random = new Random();

        static MarketExchangeRateProvider()
        {
            averageSampleRate[new CurrencyPair("GBP", "AUD")] = 1.7217M;
            averageSampleRate[new CurrencyPair("EUR", "AUD")] = 1.4464M;
            averageSampleRate[new CurrencyPair("USD", "AUD")] = 1.0749M;
            averageSampleRate[new CurrencyPair("AUD", "GBP")] = 0.5806M;
            averageSampleRate[new CurrencyPair("EUR", "GBP")] = 0.8396M;
            averageSampleRate[new CurrencyPair("USD", "GBP")] = 0.6246M;
            averageSampleRate[new CurrencyPair("AUD", "EUR")] = 0.6916M;
            averageSampleRate[new CurrencyPair("GBP", "EUR")] = 1.1912M;
            averageSampleRate[new CurrencyPair("USD", "EUR")] = 0.7440M;
            averageSampleRate[new CurrencyPair("AUD", "USD")] = 0.9296M;
            averageSampleRate[new CurrencyPair("GBP", "USD")] = 1.6011M;
            averageSampleRate[new CurrencyPair("EUR", "USD")] = 1.3442M;
        }

        public decimal GetCurrentRate(CurrencyPair sellBuyCurrencyPair)
        {
            var sampleRate = averageSampleRate[sellBuyCurrencyPair];

            return sampleRate + ((decimal)random.NextDouble() * MaxVolatility - (MaxVolatility / 2));
        }
    }
}