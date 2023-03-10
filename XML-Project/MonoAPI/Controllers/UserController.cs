using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonoAPI.DTOs.Users;
using MonoLibrary.Core.Models.ApplicationUsers;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterUserDTO dto) 
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    UserName = dto.Email,
                    Email = dto.Email
                };

                var result = await _userManager.CreateAsync(newUser, dto.Password);
                if (result.Succeeded)
                {
                    return Ok("Successfull registration.");
                }
                else 
                {
                    //Malo izmeniti ovu spiku za prikazivanje errora
                    var errorMessage = "";
                    foreach (IdentityError error in result.Errors) 
                        errorMessage = errorMessage + " " + error.Description;
                    
                    return BadRequest(errorMessage);
                }
            }
            else 
            {
                return BadRequest("Something went wrong.");
            }
        }
    }
}
