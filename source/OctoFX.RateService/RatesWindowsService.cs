using NHibernate;
using OctoFX.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OctoFX.RateService
{
    partial class RatesWindowsService : ServiceBase
    {
        readonly ISessionFactory sessionFactory;
        readonly IMarketExchangeRateProvider rateProvider;
        readonly Timer timer;

        public RatesWindowsService(ISessionFactory sessionFactory, IMarketExchangeRateProvider rateProvider)
        {
            InitializeComponent();

            this.sessionFactory = sessionFactory;
            this.rateProvider = rateProvider;
            timer = new Timer(5000) { AutoReset = true };
            timer.Elapsed += (sender, eventArgs) => GenerateNewRates();
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
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
    }
}
