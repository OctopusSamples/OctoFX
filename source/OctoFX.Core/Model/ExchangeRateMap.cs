using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class ExchangeRateMap : ClassMap<ExchangeRate>
    {
        public ExchangeRateMap()
        {
            Id(m => m.SellBuyCurrencyPair).CustomType<CurrencyPair>();
            Map(m => m.Rate);
        }
    }
}