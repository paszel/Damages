using CmsMaster.App_Start;
using CmsMaster.Helpers.Paging;
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
    public partial class HomeController : Controller
    {
        public ActionResult Index(int pageNo = 0)
        {
            var news = AppLogic.NewsLogic.GetNews(new PagingArgs() { PageSize = 10, PageNo = pageNo });

            ViewBag.TotalCount = news.PagingArgs.TotalRecords;
            ViewBag.PageSize = news.PagingArgs.PageSize;

            return View(news.Items.ToList());
        }

        public ActionResult NewsDetails(int id)
        {
            var news = AppLogic.NewsLogic.GetPublicNews(id);

            if (news == null)
            {
                return View("Index");
            }
            
            return View(news);
        }
        public ActionResult GetAvatar(string path)
        {
            return File(System.Web.HttpContext.Current.Server.MapPath(path), "image/jpeg");
        }

        public ActionResult About()
        {
            ViewBag.Avatar = AppLogic.UserLogic.GetAdminAvatarPath();
            return View(AppLogic.ContentLogic.GetContent(ContentType.About));
        }
        public ActionResult Contact()
        {
            return View(AppLogic.ContentLogic.GetContent(ContentType.Contact));
        }
        public ActionResult Partnership()
        {
            return View(AppLogic.ContentLogic.GetContent(ContentType.Partnership));
        }
    }
}
