﻿namespace Core.DependencyResolution
{
    public interface IDependencyResolver
    {
        TDependency Resolve<TDependency>();
    }
}
