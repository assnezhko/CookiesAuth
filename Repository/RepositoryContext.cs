using CookiesAuth.Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace CookiesAuth.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
