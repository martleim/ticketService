using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Tickets.API;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
        protected void Application_BeginRequest()
        {
            var originalPath = HttpContext.Current.Request.Path.ToLower();
        }
    }
}
