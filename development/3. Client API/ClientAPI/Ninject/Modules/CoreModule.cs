using Core.Serialization;
using Core.Serialization._Impl;
using Ninject.Modules;

namespace ClientAPI.Ninject.Modules
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            // Serialization
            Bind<IJsonSerializer>().To<JsonSerializer>();
        }
    }
}