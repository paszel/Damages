using CmsMaster.App_Start;
using CmsMaster.Helpers.DataTables;
using CmsMaster.Helpers.Paging;
using CmsMaster.Mailers;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsMaster.Controllers
{
    public partial class AdminController : Controller
    {
        public ActionResult NewsList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetNewsList(Params p)
        {
            var pagingArgs = new PagingArgs()
            {
                PageNo = p.iDisplayStart / p.iDisplayLength,
                PageSize = p.iDisplayLength,
            };

            var data = AppLogic.NewsLogic.GetNews(pagingArgs);
            var table = new List<List<string>>();

            var actionLink = "<a href =\"/admin/editNews?id={0}\">edytuj</a>";

            foreach (var item in data.Items)
            {
                table.Add(new List<string>(){
                    item.Title,
                    item.Created.ToString("dd-MM-yyyy"),
                    string.Format(actionLink,item.Id)
                });

            }

            return new DataTableResult(p, data.PagingArgs.TotalRecords, data.PagingArgs.TotalRecords, table);
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(NewsModel model)
        {
            if(ModelState.IsValid)
            {
                AppLogic.NewsLogic.AddNews(model);
                return View("NewsList", new { added = true });
            }
            return View(model);
        }

        public ActionResult UpdateNews(int id)
        {
            return View(AppLogic.NewsLogic.GetNews(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateNews(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                AppLogic.NewsLogic.UpdateNews(model);
                return View("NewsList", new { updated = true });
            }
            return View(model);
        }

    }
}