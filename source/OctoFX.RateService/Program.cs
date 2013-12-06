using Autofac;
using OctoFX.Core;
using System.ServiceProcess;

namespace OctoFX.RateService
{
    static class Program
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RatesWindowsService>();
            builder.RegisterType<MarketExchangeRateProvider>().As<IMarketExchangeRateProvider>();
            builder.RegisterModule<PersistenceModule>();

            var container = builder.Build();

            ServiceBase.Run(new[] { 
                container.Resolve<RatesWindowsService>() 
            });
        }
    }
}
