using ClientAPI.Ninject.Modules;
using Ninject;

namespace ClientAPI.Ninject
{
    public class NinjectBootstrapper
    {
        public IKernel CreateApplicationKernel()
        {
            return new StandardKernel(new CoreModule(),
                                      new ClientAPIModule(),
                                      new DataSourceDataAccessModule());
        }
    }
}