using CookiesAuth.Models.ODT;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ISecurityService _securityService;

        public IdentityService(IIdentityRepository identityRepository, ISecurityService securityService)
        {
            _identityRepository = identityRepository;
            _securityService = securityService;
        }

        public async Task<UserModel> GetUserAsync(string userEmail, string userPassword)
        {
            return await _identityRepository.GetUserAsync(userEmail, userPassword);
        }

        public async Task<UserModel> GetUserAsync(string userEmail)
        {
            return await _identityRepository.GetUserAsync(userEmail);
        }

        public async Task AddAsync(UserModel model)
        {
            await _identityRepository.AddAsync(model);
        }
    }
}
