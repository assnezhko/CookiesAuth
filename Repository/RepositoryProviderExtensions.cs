using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository
{
    public static class RepositoryProviderExtensions
    {

        public static void AddRepositories(this IServiceCollection services, IBaseService baseService, string connection)
        {
            baseService.AddRepositories(services, connection);
        }
    }
}
