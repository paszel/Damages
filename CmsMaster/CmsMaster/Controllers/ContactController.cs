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
            IUserMailer mailer = new UserMailer();
            mailer.Contact().Send();
            return View();
        }

 

    }
}
