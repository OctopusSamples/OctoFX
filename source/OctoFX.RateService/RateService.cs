using System;
using System.Diagnostics;
using System.Timers;
using NHibernate;
using OctoFX.Core.Model;

namespace OctoFX.RateService
{
    public class RateService
    {
        readonly ISessionFactory sessionFactory;
        private readonly IMarketExchangeRateProvider rateProvider;
        readonly Timer timer;

        public RateService(ISessionFactory sessionFactory, IMarketExchangeRateProvider rateProvider)
        {
            this.sessionFactory = sessionFactory;
            this.rateProvider = rateProvider;
            timer = new Timer(5000) { AutoReset = true };
            timer.Elapsed += (sender, eventArgs) => GenerateNewRates();
        }

        public bool Start()
        {
            timer.Start();
            return true;
        }

        void GenerateNewRates()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var rates = session.QueryOver<ExchangeRate>()
                        .List();

                    foreach (var rate in rates)
                    {
                        rate.Rate = rateProvider.GetCurrentRate(rate.SellBuyCurrencyPair);
                        Console.WriteLine("Rate for {0}: {1:n4}", rate.SellBuyCurrencyPair, rate.Rate);
                        session.Update(rate);
                    }

                    session.Flush();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public bool Stop()
        {
            timer.Stop();
            return true;
        }
    }
}