using System;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsApi
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
            _services.AddTransient<TService>();
            var provider = _services.BuildServiceProvider();
            _decoratedService = (TInterface) provider.GetService(typeof(TService));

            return this;
        }

        public DecoratorBuilder<TInterface> Envelop(Func<IServiceProvider, TInterface, TInterface> envelop)
        {
            var provider = _services.BuildServiceProvider();
            _decoratedService = envelop(provider, _decoratedService);

            return this;
        }

        public void Register()
        {
            _services.AddTransient(provider => _decoratedService);
        }
    }
}