using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using NHibernate;
using OctoFX.Core.Model;
using OctoFX.Core.Util;
using OctoFX.TradingWebsite.Models;

namespace OctoFX.TradingWebsite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ISession session;

        public AccountController(ISession session)
        {
            this.session = session;
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = session.QueryOver<Account>()
                    .Where(a => a.Email == model.Email)
                    .List().FirstOrDefault();

            if (account != null)
            {
                if (PasswordHasher.VerifyPassword(model.Password, account.PasswordHashed))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return string.IsNullOrWhiteSpace(returnUrl) ? (ActionResult)RedirectToAction("Index", "Home") : Redirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = session.QueryOver<Account>()
                    .Where(a => a.Email == model.Email)
                    .List().FirstOrDefault();

            if (account != null)
            {
                ModelState.AddModelError("Email", "An account with this email address already exists.");
                return View(model);
            }

            account = new Account();
            account.Email = model.Email;
            account.Name = model.Name;
            account.PasswordHashed = PasswordHasher.HashPassword(model.Password);
            account.IsActive = true;

            session.Save(account);

            FormsAuthentication.SetAuthCookie(account.Email, true);

            return RedirectToAction("Index", "Home");
        }
    }
}
