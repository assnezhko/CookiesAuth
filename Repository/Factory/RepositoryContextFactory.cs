using CookiesAuth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Repository
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        public RepositoryContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(connectionString, 
                t => t.MigrationsAssembly(typeof(RepositoryContext).GetTypeInfo().Assembly.GetName().Name));

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
