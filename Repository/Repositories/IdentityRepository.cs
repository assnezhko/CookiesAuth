using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CookiesAuth.Models.ODT;
using System.Linq;
using CookiesAuth.Models.ORM;

namespace Repository.Repositories
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
    {
        public IdentityRepository(string connectionString, IRepositoryContextFactory contextFactory)
            : base(connectionString, contextFactory) { }


        public async Task<UserModel> GetUserAsync(string userEmail, string userPassword)
        {
            UserModel user = await context.Users.Where(u => u.Email == userEmail && u.Password == userPassword)
                                                .Select(u => new UserModel
                                                {
                                                    UserId = u.UserId,
                                                    Email = u.Email,
                                                    PasswordHash = u.Password,
                                                    IsAdmin = u.IsAdmin
                                                }).SingleOrDefaultAsync();

            return user;
        }

        public async Task<UserModel> GetUserAsync(string userEmail)
        {
            UserModel user = await context.Users.Where(u => u.Email == userEmail)
                                                .Select(u => new UserModel
                                                {
                                                    UserId = u.UserId,
                                                    Email = u.Email,
                                                    PasswordHash = u.Password,
                                                    IsAdmin = u.IsAdmin
                                                }).SingleOrDefaultAsync();

            return user;
        }

        public async Task AddAsync(UserModel user)
        {

            await context.Users.AddAsync(new User
            {
                Email = user.Email,
                Password = user.PasswordHash,
                IsAdmin = user.IsAdmin
            });

            await context.SaveChangesAsync();
        }
    }
}
