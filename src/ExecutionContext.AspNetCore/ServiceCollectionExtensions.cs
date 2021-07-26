using Etherna.ExecContext.AsyncLocal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Etherna.ExecContext.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExecutionContext(
            this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.TryAddSingleton<IExecutionContext>(serviceProvider =>
               new ExecutionContextSelector(new IExecutionContext[] //default
               {
                    new HttpContextExecutionContext(serviceProvider.GetRequiredService<IHttpContextAccessor>()),
                    AsyncLocalContext.Instance
               }));

            return services;
        }
    }
}
