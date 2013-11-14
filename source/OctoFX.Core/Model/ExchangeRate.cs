namespace OctoFX.Core.Model
{
    public class ExchangeRate
    {
        protected ExchangeRate()
        {
            
        }

        public ExchangeRate(CurrencyPair currencyPair, decimal buyRate, decimal sellRate) : this()
        {
            CurrencyPair = currencyPair;
            BuyRate = buyRate;
            SellRate = sellRate;
        }

        public virtual CurrencyPair CurrencyPair { get; protected set; }
        public virtual decimal BuyRate { get; protected set; }
        public virtual decimal SellRate { get; protected set; }
    }
}