using System;

namespace Core.DependencyResolution
{
    public interface IDependencyResolver
    {
        object Resolve(Type dependencyType);

        TDependency Resolve<TDependency>();
    }
}
