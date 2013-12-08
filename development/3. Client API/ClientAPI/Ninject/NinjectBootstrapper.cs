using ClientAPI.Ninject.Modules;
using Ninject;

namespace ClientAPI.Ninject
{
    public class NinjectBootstrapper
    {
        public IKernel RegisterApplicationModules(IKernel kernel)
        {
            kernel.Load(new CoreModule(),
                        new DataAccessModule(),
                        new ClientAPIModule(),
                        new DataSourceDataAccessModule());

            return kernel;
        }
    }
}