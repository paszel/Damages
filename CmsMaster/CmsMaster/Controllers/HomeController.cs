using CmsMaster.App_Start;
using CmsMaster.Mailers;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CmsMaster.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                if (AppLogic.UserLogic.IsAuthenticated(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("CustomValidation", "Dane niepoprawne");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgetPassword()
        {
            UserMailer mailer = new UserMailer();

            mailer.ToEmail = AppLogic.UserLogic.GetAdminEmail().Email;

            string newPassword = "test123";
            AppLogic.UserLogic.ChangePassword(newPassword);
            mailer.Password = newPassword;
            mailer.Name = "Przemek";
            mailer.Contact().Send();

            ViewBag.Changed = true;

            return View("Index");
        }

    }
}
