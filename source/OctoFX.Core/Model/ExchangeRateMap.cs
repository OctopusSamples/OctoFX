using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class ExchangeRateMap : ClassMap<ExchangeRate>
    {
        public ExchangeRateMap()
        {
            Id(m => m.SellBuyCurrencyPair).GeneratedBy.Assigned().CustomType<CurrencyPairUserType>().Column("SellBuyCurrencyPair");
            Map(m => m.Rate);
        }
    }
}