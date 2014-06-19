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
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            UserMailer mailer = new UserMailer();

            mailer.ToEmail = AppLogic.UserLogic.GetAdminEmail().Email;

            string newPassword = "test123";
            AppLogic.UserLogic.ChangePassword(newPassword);
            mailer.Password = newPassword;
            mailer.Name = "Przemek";
            mailer.Contact().Send();
            return View();
        }

 

    }
}
