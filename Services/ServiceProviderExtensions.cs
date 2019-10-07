using Microsoft.Extensions.DependencyInjection;
using System;

namespace Services
{
    public static class ServiceProviderExtensions
    {
        public static void AddServices(this IServiceCollection services, IBaseService baseService)
        {
            baseService.AddServices(services);
        }
    }
}
