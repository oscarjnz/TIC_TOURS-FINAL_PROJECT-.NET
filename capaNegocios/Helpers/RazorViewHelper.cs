using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace capaNegocios.Helpers
{
    public class RazorViewHelper
    {
       
            public static string RenderViewToString(string viewName, object model)
            {
                var httpContext = new HttpContextWrapper(System.Web.HttpContext.Current);
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Fake");

                var controllerContext = new ControllerContext(new RequestContext(httpContext, routeData), new FakeController());

                var viewEngineResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                if (viewEngineResult.View == null)
                {
                    throw new InvalidOperationException($"No se encontró la vista {viewName}");
                }

                var view = viewEngineResult.View;

                controllerContext.Controller.ViewData.Model = model;

                using (var sw = new StringWriter())
                {
                    var viewContext = new ViewContext(controllerContext, view, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                    view.Render(viewContext, sw);
                    return sw.ToString();
                }
            }

            private class FakeController : Controller { }
        
    }
}