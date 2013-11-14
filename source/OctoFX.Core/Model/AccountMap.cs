using FluentNHibernate.Mapping;

namespace OctoFX.Core.Model
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.Email);
            Map(m => m.Name);
            Map(m => m.PasswordHashed);
            Map(m => m.IsActive);
        }
    }
}