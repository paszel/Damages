using CmsMaster.App_Start;
using CmsMaster.Mailers;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsMaster.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeEmail()
        {
            return View(AppLogic.UserLogic.GetAdminEmail());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeEmail(UserEmail user)
        {
            if(ModelState.IsValid)
            {
                if (AppLogic.UserLogic.IsAuthenticated("admin", user.Password))
                {
                    AppLogic.UserLogic.ChangeEmail(user.Email);
                    ViewBag.Update = true;
                    return View("Index");
                }
                else
                {
                    ModelState.AddModelError("Password", "Hasło nie przeszło walidacji");
                }
            }

            user.Password = string.Empty;
            return View("ChangeEmail", user);
        }

        

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserPassword user)
        {
            if(ModelState.IsValid)
            {
                if (user.OldPassword.Trim() != user.NewPassword.Trim())
                {
                    if (AppLogic.UserLogic.IsAuthenticated("admin", user.OldPassword))
                    {
                        AppLogic.UserLogic.ChangePassword(user.NewPassword);
                        ViewBag.Update = true;
                        return View("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("OldPassword", "Stare hasło jest niepoprawne");
                    }
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Stare i nowe hasło jest takie same");
                }
            }

            return View("ChangePassword");
        }

    }
}
