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
        public ActionResult CooperatorsList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCooperatorsList(Params p)
        {
            var pagingArgs = new PagingArgs()
            {
                PageNo = p.iDisplayStart / p.iDisplayLength,
                PageSize = p.iDisplayLength,
            };

            var data = AppLogic.CooperatorLogic.GetCooperators(pagingArgs);
            var table = new List<List<string>>();

            var actionLink = "<a href =\"/admin/updateCooperator?id={0}\">edytuj</a> | <a href =\"/admin/deleteCooperator?id={0}\" class=\"deleteAction\">usuń</a>";

            foreach (var item in data.Items)
            {
                table.Add(new List<string>(){
                    item.Title,
                    item.Created.ToString("dd-MM-yyyy"),
                    item.UrlAddress,
                    item.IsBanner ? "tak" : "nie",
                    string.Format(actionLink,item.Id)
                });

            }

            return new DataTableResult(p, data.PagingArgs.TotalRecords, data.PagingArgs.TotalRecords, table);
        }

        public ActionResult AddCooperator()
        {
            return View(new CooperatorModel());
        }

        [HttpPost]
        public ActionResult AddCooperator(CooperatorModel model, HttpPostedFileBase image)
        {
            if(ModelState.IsValid)
            {
                var id = AppLogic.CooperatorLogic.AddCooperator(model);

                if (image != null)
                {
                    var path = SaveImagePath("Cooperators", id.ToString(), image);
                    AppLogic.CooperatorLogic.SaveCooperatorImage(id, path, path.Split('/').Last());
                }

                return RedirectToAction("CooperatorsList", new { added = true });
            }
            return View(model);
        }

        public ActionResult UpdateCooperator(int id)
        {
            return View(AppLogic.CooperatorLogic.GetCooperator(id));
        }

        [HttpPost]
        public ActionResult UpdateCooperator(CooperatorModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                AppLogic.CooperatorLogic.UpdateCooperator(model);

                if (image != null)
                {
                    var path = SaveImagePath("Cooperators", model.Id.ToString(), image);
                    AppLogic.CooperatorLogic.SaveCooperatorImage(model.Id, path, path.Split('/').Last());
                }

                return RedirectToAction("CooperatorsList", new { updated = true });
            }
            return View(model);
        }

        public ActionResult DeleteCooperator(int id)
        {
            AppLogic.CooperatorLogic.DeleteCooperator(id);
            return RedirectToAction("CooperatorsList", new { updated = true });
        }

    }
}