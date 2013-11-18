using System;
using System.Web.Mvc;
using NHibernate;
using OctoFX.Core.Model;
using OctoFX.TradingWebsite.Models;

namespace OctoFX.TradingWebsite.Controllers
{
    [Authorize]
    public class DealController : Controller
    {
        private readonly ISession session;

        public DealController(ISession session)
        {
            this.session = session;
        }

        //
        // GET: /Deal/Quote

        public ActionResult Quote()
        {
            return View(new QuoteModel { SellCurrency = Currency.Gbp, BuyCurrency = Currency.Usd });
        }

        //
        // POST: /Deal/Quote

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quote(QuoteModel model)
        {
            if (model.SellCurrency == model.BuyCurrency)
                ModelState.AddModelError("", "The buy and sell currencies are both the same. Please choose a different currency for either buy or sell.");

            if (model.QuantityToSell < 100) ModelState.AddModelError("QuantityToSell", "Minimum conversion is 100 " + model.SellCurrency);
            if (model.QuantityToSell > 100000) ModelState.AddModelError("QuantityToSell", "Maximum conversion is 100,000 " + model.SellCurrency);
            if (!ModelState.IsValid)
                return View(model);

            var pair = new CurrencyPair(model.SellCurrency, model.BuyCurrency);
            var rate = session.QueryOver<ExchangeRate>()
                .Where(r => r.SellBuyCurrencyPair == pair)
                .SingleOrDefault();

            if (rate == null)
            {
                ModelState.AddModelError("", "Cannot convert between the selected currencies.");
                return View(model);
            }

            // Generate a quote
            var quote = OctoFX.Core.Model.Quote.Create(rate, model.QuantityToSell, DateTimeOffset.UtcNow);
            session.Save(quote);

            return RedirectToAction("Deal", "Deal", new {quoteId = quote.Id});
        }

        public ActionResult Deal(int quoteId)
        {
            var quote = session.QueryOver<Quote>()
                .Where(q => q.Id == quoteId)
                .SingleOrDefault();

            if (quote == null || quote.HasExpired(DateTimeOffset.UtcNow))
            {
                return RedirectToAction("Quote");
            }

            var model = new DealModel();
            model.Quote = quote;
            model.QuoteId = quoteId;

            return View(model);
        }
    }
}