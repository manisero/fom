using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using ClientAPI._Impl;

namespace ClientAPI
{
    public class Global : HttpApplication
    {
        private const string SERVICE_ROUTE_PREFIX_TEMPLATE = "api/{0}";

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute(string.Format(SERVICE_ROUTE_PREFIX_TEMPLATE, "Restaurant"), new WebServiceHostFactory(), typeof(RestaurantService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}