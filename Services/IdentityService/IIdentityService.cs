using CookiesAuth.Models.ODT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IIdentityService
    {
        Task<UserModel> GetUserAsync(string userEmail, string userPassword);

        Task<UserModel> GetUserAsync(string userEmail);

        Task AddAsync(UserModel user);
    }
}
