using Microsoft.AspNetCore.Identity;
using MonoLibrary.Core.Models.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services.Core
{
    public interface IAuthService
    {
        Task<IdentityResult> Create(User user, string password, bool isAdmin);
        Task<IdentityResult> Register(Customer newCustomer, string password);
        Task<SignInResult> Login(string email, string password, bool rememeberMe);
        Task<string> GetUserRole(string email);
        Task<User> FindByEmail(string email);
        Task Logout();
        Task SignIn(User user);
    }
}
