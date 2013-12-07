using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using ClientAPI.AutoMapper;
using ClientAPI._Impl;

namespace ClientAPI
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new AutoMapperBootstrapper().Bootstrap();

            RouteTable.Routes.Add(new ServiceRoute("api", new WebServiceHostFactory(), typeof(ClientAPIService)));
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