using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class ExchangeRateMap : ClassMap<ExchangeRate>
    {
        public ExchangeRateMap()
        {
            Id(m => m.CurrencyPair).CustomType<CurrencyPairUserType>(); ;
            Map(m => m.BuyRate);
            Map(m => m.SellRate);
        }
    }
}