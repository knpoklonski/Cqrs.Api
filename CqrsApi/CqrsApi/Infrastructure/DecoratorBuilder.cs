using System;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsApi.Infrastructure
{
    public class DecoratorBuilder<TInterface> where TInterface : class
    {
        private readonly IServiceCollection _services;
        private TInterface _decoratedService;

        public DecoratorBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public DecoratorBuilder<TInterface> Default<TService>()
            where TService : class, TInterface
        {
            ServiceCollectionServiceExtensions.AddTransient<TService>(_services);
            var provider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(_services);
            _decoratedService = (TInterface) provider.GetService(typeof(TService));

            return this;
        }

        public DecoratorBuilder<TInterface> Envelop(Func<IServiceProvider, TInterface, TInterface> envelop)
        {
            var provider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(_services);
            _decoratedService = envelop(provider, _decoratedService);

            return this;
        }

        public void Register()
        {
            _services.AddTransient(provider => _decoratedService);
        }
    }
}