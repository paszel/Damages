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

namespace CmsMaster
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
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

            //container.InterceptWith<InterceptionProcessor>(t =>
            //    t.Name.EndsWith("Logic")
            //);

            Application["Container"] = container;
        }
    }
}