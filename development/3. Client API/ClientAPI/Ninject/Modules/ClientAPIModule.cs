using Core.DependencyResolution;
using DataSource.DataAccess;
using Ninject.Modules;

namespace ClientAPI.Ninject.Modules
{
    public class ClientAPIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataAccessSettingsProvider>().To<SettingsProvider>();

            // Ninject
            Bind<IDependencyResolver>().ToConstant(new NinjectDependencyResolver(Kernel));
        }
    }
}