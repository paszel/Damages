using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using CmsMaster.ILogic;
using CmsMaster.Logic;
using log4net;
using System.Reflection;
using log4net.Config;
using CmsMaster.Mailers;

namespace CmsMaster
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Register<IUserLogic, UserLogic>(Lifestyle.Singleton);
            container.Register<INewsLogic, NewsLogic>(Lifestyle.Singleton);
            container.Register<IContentLogic, ContentLogic>(Lifestyle.Singleton);
            container.Register<ICooperatorLogic, CooperatorLogic>(Lifestyle.Singleton);

            Application["Container"] = container;
            XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e) 
        {
            var exception = Server.GetLastError().GetBaseException();
            Logger.Error(string.Format("{0} / {1}", DateTime.Now, Request.Url), exception);

            UserMailer mailer = new UserMailer();
            mailer.CustomError(exception, Request.Url.ToString()).Send();

            Response.Redirect("/Error/NotFound");
        }
    }
}