using System;
using Core.DependencyResolution;
using Ninject;

namespace ClientAPI.Ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object Resolve(Type dependencyType)
        {
            return _kernel.Get(dependencyType);
        }

        public TDependency Resolve<TDependency>()
        {
            return _kernel.Get<TDependency>();
        }
    }
}