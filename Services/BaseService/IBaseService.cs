using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBaseService
    {
        void AddServices(IServiceCollection services);
    }
}
