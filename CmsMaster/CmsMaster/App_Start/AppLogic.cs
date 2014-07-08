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
        public static IUserLogic UserLogic
        {
            get
            {
                return ((Container)HttpContext.Current.Application["Container"]).GetInstance<IUserLogic>();
            }
        }
        public static INewsLogic NewsLogic
        {
            get
            {
                return ((Container)HttpContext.Current.Application["Container"]).GetInstance<INewsLogic>();
            }
        }
        public static ICooperatorLogic CooperatorLogic
        {
            get
            {
                return ((Container)HttpContext.Current.Application["Container"]).GetInstance<ICooperatorLogic>();
            }
        }

        public static IContentLogic ContentLogic
        {
            get
            {
                return ((Container)HttpContext.Current.Application["Container"]).GetInstance<IContentLogic>();
            }
        }

    }
}