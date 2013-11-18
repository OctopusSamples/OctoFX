using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class QuoteMap : ClassMap<Quote>
    {
        public QuoteMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();

            Map(m => m.SellBuyCurrencyPair).CustomType<CurrencyPairUserType>();
            Map(m => m.BuyAmount);
            Map(m => m.SellAmount);
            Map(m => m.ExpiryDate);
            Map(m => m.QuotedDate);
            Map(m => m.Rate);
        }
    }
}