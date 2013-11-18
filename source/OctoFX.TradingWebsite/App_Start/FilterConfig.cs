using System.Web;
using System.Web.Mvc;
using OctoFX.TradingWebsite.Filters;

namespace OctoFX.TradingWebsite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UnitOfWorkFilter());
        }
    }
}