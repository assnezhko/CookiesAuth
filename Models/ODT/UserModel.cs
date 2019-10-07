using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesAuth.Models.ODT
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        public int Id => this.UserId;
    }
}
