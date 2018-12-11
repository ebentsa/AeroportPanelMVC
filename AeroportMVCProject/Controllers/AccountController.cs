using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AeroportBusinessLogic;
using AeroportBusinessLogic.AccountMethods;
using AeroportBusinessLogic.Models;
using Microsoft.AspNet.Identity;

namespace AeroportWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount accountManager;
        public AccountController(IAccount accountManager)
        {
            this.accountManager = accountManager;
           
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                if (accountManager.Login(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Flights");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
            
        }
        [Authorize(Roles = "Supervisor")]
        public ActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "Supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                if (!(accountManager.CheckUser(model)))
                {
                    accountManager.AddUser(model);
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Flights");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);

        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}