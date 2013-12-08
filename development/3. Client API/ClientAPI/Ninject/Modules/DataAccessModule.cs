using System.Data.Entity;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository._Impl;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ClientAPI.Ninject.Modules
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            // Repository
            Bind<DbContext>().To<DataContext>().InRequestScope();
            Bind<IUnitOfWork>().To<EntityFrameworkUnitOfWork>();
            Bind<IRepositoryFactory>().To<EntityFrameworkRepositoryFactory>();
        }
    }
}