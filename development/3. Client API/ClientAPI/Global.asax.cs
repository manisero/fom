using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using ClientAPI.AutoMapper;
using ClientAPI.Ninject;
using ClientAPI._Impl;
using Core.DependencyResolution;
using Ninject;

namespace ClientAPI
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new AutoMapperBootstrapper().Bootstrap();

            var kernel = new NinjectBootstrapper().CreateApplicationKernel();
            DependencyResolverContainer.DependencyResolver = kernel.Get<IDependencyResolver>();

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