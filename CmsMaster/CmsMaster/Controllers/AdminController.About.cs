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
        public ActionResult About()
        {
            var content = AppLogic.ContentLogic.GetContent(ContentType.About);

            return View(new AboutModel()
            {
                Content = content.ContentDescription,
                Avatar = AppLogic.UserLogic.GetAdminAvatarPath()
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult About(
            HttpPostedFileBase avatar,
            AboutModel model)
        {
            if (ModelState.IsValid)
            {
                AppLogic.ContentLogic.EditContent(new ContentModel()
                {
                    ContentDescription = model.Content,
                    Type = ContentType.About
                });

                if (avatar != null)
                {
                    AppLogic.UserLogic.SaveAvatarPath(SaveImagePath(avatar));
                }

                return RedirectToAction("Index", new { updated = true });
            }
            return View(model);
        }

        private string SaveImagePath(HttpPostedFileBase image)
        {
            if (image.ContentLength > 0)
            {
                var resourceDir = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/AppData/Avatar/"));

                DirectoryHelper.CreateDirectoryNested(resourceDir);

                var fileExtension = image.FileName.Split('.')[1];
                var fileName = string.Format("adminAvatar.{0}", fileExtension.ToLower());

                var path = string.Format("/AppData/Avatar/{0}", fileName);

                var imgWidth = 960;
                var imgQuality = 95L;

                var fileStream = image.InputStream;

                var imgPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(path));

                ImageHelper.SaveImageAs(
                    System.Drawing.Image.FromStream(fileStream),
                    ImageHelper.ImageProcessingArgs.Width(imgWidth).SaveAsJpg(imgQuality),
                    imgPath);

                return path;
            }

            return AppLogic.UserLogic.GetAdminAvatarPath();
        }

        public ActionResult GetAvatar(string path)
        {
            return File(System.Web.HttpContext.Current.Server.MapPath(path), "image/jpeg");
        }

    }
}
