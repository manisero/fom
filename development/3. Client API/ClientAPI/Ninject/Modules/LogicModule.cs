using Logic.DataManagement;
using Logic.DataManagement._Impl;
using Ninject.Modules;

namespace ClientAPI.Ninject.Modules
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}