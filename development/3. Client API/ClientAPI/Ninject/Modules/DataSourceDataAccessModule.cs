using DataSource.DataAccess;
using DataSource.DataAccess._Impl;
using Ninject.Modules;

namespace ClientAPI.Ninject.Modules
{
    public class DataSourceDataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRestClient>().To<RestClient>();
            Bind<IDataProvider>().To<DataProvider>();
        }
    }
}