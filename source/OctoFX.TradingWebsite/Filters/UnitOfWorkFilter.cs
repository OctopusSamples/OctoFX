using System.Web.Mvc;
using NHibernate;

namespace OctoFX.TradingWebsite.Filters
{
    public class UnitOfWorkFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = DependencyResolver.Current.GetService<ISession>();
            filterContext.HttpContext.Items["ThisTransaction"] = session.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                var session = DependencyResolver.Current.GetService<ISession>();
                var transaction = (ITransaction)filterContext.HttpContext.Items["ThisTransaction"];
                session.Flush();
                transaction.Commit();                
            }
        }
    }
}