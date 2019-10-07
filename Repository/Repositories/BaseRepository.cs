using CookiesAuth.Models;

namespace Repository
{
    public abstract class BaseRepository
    {
        protected string ConnectionString { get; }
        protected IRepositoryContextFactory ContextFactory { get; }
        protected RepositoryContext context { get; }

        public BaseRepository(string connectionString, IRepositoryContextFactory contextFactory)
        {
            ConnectionString = connectionString;
            ContextFactory = contextFactory;
            context = ContextFactory.CreateDbContext(ConnectionString);
        }
    }
}
