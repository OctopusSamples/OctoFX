using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class DealMap : ClassMap<Deal>
    {
        public DealMap()
        {
            Id(m => m.Id);

            Map(m => m.BuyCurrency).CustomType<CurrencyUserType>();
            Map(m => m.SellCurrency).CustomType<CurrencyUserType>();
            Map(m => m.BuyAmount);
            Map(m => m.SellAmount);
            Map(m => m.Status);
            Map(m => m.EnteredDate);

            References(m => m.NominatedBeneficiaryAccount).LazyLoad().Column("NominatedBeneficiaryAccountId");
            References(m => m.Account).LazyLoad().Column("AccountId");
        }
    }
}