using System.Web.Mvc;
using NHibernate;
using OctoFX.Core.Model;

namespace OctoFX.TradingWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;

        public HomeController(ISession session)
        {
            this.session = session;
        }

        public ActionResult Index()
        {
            var rates = session.QueryOver<ExchangeRate>()
                .List();

            return View(rates);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
