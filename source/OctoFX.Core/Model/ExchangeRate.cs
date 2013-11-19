namespace OctoFX.Core.Model
{
    /// <summary>
    /// Exchange rates specify the rate at which a customer can sell a quantity of one currency to OctoFX in order to buy another. 
    /// </summary>
    /// <example>
    /// For example, imagine the following rate:
    /// <code>
    ///  Sell: USD
    ///  Buy: AUD
    ///  Rate: 1.0749
    /// </code>
    /// Given USD $1000, if I /sold/ them to OctoFX in order to /buy/ AUD, I'd be buying AUD $1074.90.
    /// 
    /// Note that when the buy/sell currency swap, the rate won't always be the inverse because we keep a few basis points as our profit. 
    /// For example, if they sold 1074.90 AUD for USD, they would be likely to get a rate of 0.9296, or 999.23 USD. The seventy seven cents that 
    /// is missing is our profit margin. When the currencies swap, a different <see cref="ExchangeRate"/> should be used. Conceptually, the 
    /// exchange rate for AUD/USD is unrelated to the exchange rate for USD/AUD, and one can't be simply swapped for another.
    /// </example>
    /// <remarks>
    /// </remarks>
    public class ExchangeRate
    {
        protected ExchangeRate()
        {
            
        }

        public ExchangeRate(CurrencyPair sellBuyCurrencyPair, decimal rate)
            : this()
        {
            SellBuyCurrencyPair = sellBuyCurrencyPair;
            Rate = rate;
        }

        public virtual CurrencyPair SellBuyCurrencyPair { get; protected set; }
        public virtual decimal Rate { get; set; }

        public virtual decimal QuoteWhenIntendingToSell(decimal quantityToSell)
        {
            return Rate*quantityToSell;
        }

        public virtual decimal QuoteWhenIntendingToBuy(decimal quantityToBuy)
        {
            return quantityToBuy / Rate;
        }

        public override string ToString()
        {
            return string.Format("{0}: {2:n4}", SellBuyCurrencyPair, Rate);
        }
    }
}