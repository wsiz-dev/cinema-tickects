using Autofac;
using CinemaTickets.Domain;

namespace CinemaTickets.Infrastructure
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacDependencyResolver(ILifetimeScope lifetimeScope)
        {
            this._lifetimeScope = lifetimeScope;
        }

        public T ResolveOrDefault<T>() where T : class
            => _lifetimeScope.ResolveOptional<T>();
    }
}
