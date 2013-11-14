using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using OctoFX.Core.Model;

namespace OctoFX.SampleDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = Fluently
                .Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString("server=(local)\\SQLExpress;trusted_connection=true;Database=OctoFX1"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Deal>())
                .BuildSessionFactory();

            using (var session = factory.OpenSession())
            {
                //session.SaveOrUpdate(new ExchangeRate(new CurrencyPair(Currency.Usd, Currency.Gbp), 1.109m, 0.993m));
                //session.SaveOrUpdate(new ExchangeRate(new CurrencyPair(Currency.Aud, Currency.Gbp), 1.109m, 0.993m));
                //session.SaveOrUpdate(new ExchangeRate(new CurrencyPair(Currency.Aud, Currency.Eur), 1.109m, 0.993m));

                //var account = new Account
                //{
                //    Email = "paul6@paulstovell.com",
                //    IsActive = true,
                //    PasswordHashed = "ABC123",
                //    Name = "Paul Stovell"
                //};

                //session.SaveOrUpdate(account);

                //var beneficiary = new BeneficiaryAccount
                //{
                //    Account = account,
                //    AccountNumber = "23189810091",
                //    Country = "AU",
                //    Currency = Currency.Aud,
                //    IsActive = true,
                //    Nickname = "CommBank AUD account",
                //    SwiftBicBsb = "123 312"
                //};
                //session.SaveOrUpdate(beneficiary);


                //session.SaveOrUpdate(new Deal
                //{
                //    Account = account,
                //    NominatedBeneficiaryAccount = beneficiary,
                //    BuyAmount = 1000,
                //    BuyCurrency = Currency.Aud,
                //    SellAmount = 1100,
                //    SellCurrency = Currency.Usd,
                //    EnteredDate = DateTimeOffset.UtcNow,
                //    Status = DealStatus.AwaitingFunds
                //});

                //session.Flush();
            }
        }
    }
}
