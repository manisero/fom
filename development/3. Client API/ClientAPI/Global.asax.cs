using System;
using System.Data.Entity;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using ClientAPI.AutoMapper;
using DataAccess;
using Ninject.Extensions.Wcf;

namespace ClientAPI
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, DataAccess.Migrations.Configuration>());
            new AutoMapperBootstrapper().Bootstrap();

            RouteTable.Routes.Add(new ServiceRoute("api", new NinjectWebServiceHostFactory(), typeof(ClientAPIService)));
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