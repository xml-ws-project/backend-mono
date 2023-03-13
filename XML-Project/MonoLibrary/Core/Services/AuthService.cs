using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private RoleManager<Role> _roleManager;
        public AuthService(UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> Create(User user, string password, bool isAdmin)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (isAdmin)
                await AddToRole(user.Email, "ADMIN");

            return result;
        }
        public async Task<IdentityResult> Register(Customer newCustomer, string password) 
        {
            var result = await _userManager.CreateAsync(newCustomer, password);
            await AddToRole(newCustomer.Email, "CUSTOMER");
            return result;
        }

        private async Task AddToRole(string email, string role) 
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _userManager.AddToRoleAsync(user, role);
            return;
        }
        public async Task<SignInResult> Login(string email, string password, bool rememeberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, rememeberMe, lockoutOnFailure: false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SignIn(User user)
        {
            await _signInManager.SignInAsync(user, isPersistent : false);
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
