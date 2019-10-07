using CookiesAuth.Models.ODT;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IIdentityRepository
    {
        Task<UserModel> GetUserAsync(string userEmail, string userPassword);

        Task<UserModel> GetUserAsync(string userEmail);

        Task AddAsync(UserModel user);
    }
}
