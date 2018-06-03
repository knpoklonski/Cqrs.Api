using Microsoft.Extensions.DependencyInjection;

namespace CqrsApi
{
    public static class ServiceCollectionExtensions
    {
        public static DecoratorBuilder<TInterface> DecoratorFor<TInterface>(this IServiceCollection services) where TInterface : class
        {
            return new DecoratorBuilder<TInterface>(services);
        }
    }
}