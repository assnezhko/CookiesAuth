using CookiesAuth.Models;
using CookiesAuth.Models.ORM;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public static class DbInitializer
    {
        public async static Task Initialize(RepositoryContext context, IEnumerable<User> users)
        {
            await context.Database.MigrateAsync();

            var userCount = await context.Users.CountAsync().ConfigureAwait(false);
            if (userCount == 0)
            {
                await context.Users.AddRangeAsync(users);

                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
