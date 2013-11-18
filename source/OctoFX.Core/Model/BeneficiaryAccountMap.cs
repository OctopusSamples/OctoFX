using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class BeneficiaryAccountMap : ClassMap<BeneficiaryAccount>
    {
        public BeneficiaryAccountMap()
        {
            Id(m => m.Id);
            Map(m => m.Nickname);
            Map(m => m.AccountNumber);
            Map(m => m.SwiftBicBsb);
            Map(m => m.Currency).CustomType<CurrencyUserType>();
            Map(m => m.Country);
            Map(m => m.IsActive);

            References(m => m.Account).Column("AccountId");
        }
    }
}