using System.Configuration;
using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OctoFX.Core.Model;

namespace OctoFX.Core
{
    public class PersistenceModule : Module
    {
        public static string OctoFxDatabaseConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["OctoFXDatabase"].ConnectionString;
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var factory = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(OctoFxDatabaseConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Deal>())
                .BuildSessionFactory();

            builder.RegisterInstance(factory).As<ISessionFactory>();
            builder.Register(c => factory.OpenSession()).As<ISession>().InstancePerLifetimeScope();
        }
    }
}