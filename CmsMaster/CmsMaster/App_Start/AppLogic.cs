using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmsMaster.ILogic;
using SimpleInjector;

namespace CmsMaster.App_Start
{
    public static class AppLogic
    {
        public static IAuthenticationLogic Authentication
        {
            get
            {
                return ((Container)HttpContext.Current.Application["Container"]).GetInstance<IAuthenticationLogic>();
            }
        }
    }
}