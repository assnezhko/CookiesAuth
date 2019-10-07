using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IBaseService
    {
        void AddRepositories(IServiceCollection services, string connection);
    }
}
