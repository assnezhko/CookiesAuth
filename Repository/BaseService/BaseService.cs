using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BaseService : IBaseService
    {
        public void AddRepositories(IServiceCollection services, string connection)
        {
            services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
            services.AddScoped<IIdentityRepository>(provider => new IdentityRepository(connection, provider.GetService<IRepositoryContextFactory>()));
        }
    }
}
