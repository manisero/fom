using ClientAPI.Ninject.Modules;
using Ninject;

namespace ClientAPI.Ninject
{
    public class NinjectBootstrapper
    {
        public IKernel RegisterApplicationModules(IKernel kernel)
        {
            kernel.Load(new CoreModule(),
                        new DataSourceDataAccessModule(),
                        new DataAccessModule(),
                        new LogicModule(),
                        new ClientAPIModule());

            return kernel;
        }
    }
}