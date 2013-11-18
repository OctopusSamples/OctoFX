using System;

namespace OctoFX.Core.Model
{
    public class Quote
    {
        protected Quote()
        {
        }

        public virtual int Id { get; protected set; }
        public virtual CurrencyPair SellBuyCurrencyPair { get; protected set; }
        public virtual decimal Rate { get; protected set; }
        public virtual decimal SellAmount { get; protected set; }
        public virtual decimal BuyAmount { get; protected set; }
        public virtual DateTimeOffset QuotedDate { get; protected set; }
        public virtual DateTimeOffset ExpiryDate { get; protected set; }

        public virtual bool HasExpired(DateTimeOffset now)
        {
            return now > ExpiryDate;
        }

        public static Quote Create(ExchangeRate rate, decimal sellQuantity, DateTimeOffset now)
        {
            return new Quote
            {
                SellBuyCurrencyPair = rate.SellBuyCurrencyPair,
                BuyAmount = rate.QuoteWhenIntendingToSell(sellQuantity),
                ExpiryDate = now.AddMinutes(5),
                QuotedDate = now,
                Rate = rate.Rate,
                SellAmount = sellQuantity
            };
        }
    }
}