using CookiesAuth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRepositoryContextFactory
    {
        RepositoryContext CreateDbContext(string connectionString);
    }
}
