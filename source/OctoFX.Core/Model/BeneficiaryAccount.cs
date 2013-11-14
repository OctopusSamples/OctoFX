using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class BeneficiaryAccount
    {
        public virtual int Id { get; set; }
        public virtual Account Account { get; set; }
        public virtual string Nickname { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string SwiftBicBsb { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual string Country { get; set; }
        public virtual bool IsActive { get; set; }
    }

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