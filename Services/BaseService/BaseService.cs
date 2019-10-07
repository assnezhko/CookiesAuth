using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class BaseService: IBaseService
    {
        public void AddServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddSingleton<ISecurityService, SecurityService>();
        }
    }
}
