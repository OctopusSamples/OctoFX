using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoFX.Core.Model;

namespace OctoFX.Core
{



    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<BeneficiaryAccount>()
                .HasKey(m => m.Id);

            modelBuilder.ComplexType<Currency>();

            modelBuilder.Entity<Deal>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<ExchangeRate>()
                .HasKey(m => m.CurrencyPair);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BeneficiaryAccount> BeneficiaryAccounts { get; set; }
        public DbSet<Deal> Deal { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
