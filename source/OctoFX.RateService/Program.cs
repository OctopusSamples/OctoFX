using Autofac;
using OctoFX.Core;
using Topshelf;
using Topshelf.Autofac;

namespace OctoFX.RateService
{
    static class Program
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RateService>();
            builder.RegisterType<MarketExchangeRateProvider>().As<IMarketExchangeRateProvider>();
            builder.RegisterModule<PersistenceModule>();

            var container = builder.Build();

            HostFactory.Run(c =>
            {
                c.Service<RateService>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });

                c.UseAutofacContainer(container);

                c.SetServiceName("OctoFXRateService");
                c.SetDisplayName("OctoFX Rate Service");
                c.SetDescription("OctoFX Rate Service: Calculates exchange rates in real time");

                c.StartAutomaticallyDelayed();
                
                c.RunAsNetworkService();
            });
        }
    }
}
