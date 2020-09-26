using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSViewEngine1.VAL
{
    public class DBDrivenViewEngine : IViewEngine
    {

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext.RouteData.Values.ContainsValue("Dynamic"))
            {
            return new ViewEngineResult(new DBDrivenView(partialViewName), this);
            }
            else
            {
                return new ViewEngineResult(new string[] { "No Suitable view found for 'DbDataViewEngine', please ensure View Name contains 'Dynamic'" });
            }
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
           if (controllerContext.RouteData.Values.ContainsValue("Dynamic"))
            {
          return new ViewEngineResult(new DBDrivenView(viewName), this);
            }
            else
            {
                return new ViewEngineResult(new string[] 
                { @"No Suitable view found for 'DbDataViewEngine', 
                please ensure View Name contains 'Dynamic'" });
            }
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {

        }

    }
}