using CmsMaster.App_Start;
using CmsMaster.Helpers;
using CmsMaster.Mailers;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsMaster.Controllers
{
    public partial class AdminController : Controller
    {
        public ActionResult Contact()
        {
            return View(AppLogic.ContentLogic.GetContent(ContentType.Contact));
        }

        [HttpPost]
        public ActionResult Content(ContentModel model)
        {
            if (ModelState.IsValid)
            {
                model.Type = ContentType.Contact;
                AppLogic.ContentLogic.EditContent(model);

                return RedirectToAction("Index", new { updated = true });
            }

            return View(model);
        }
    }
}
