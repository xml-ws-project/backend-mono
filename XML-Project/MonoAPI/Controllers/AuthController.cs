﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonoAPI.DTOs.Auth;
using MonoAPI.DTOs.Users;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Services.Core;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(RegisterUserDTO dto)
        {
            var user = await _authService.FindByEmail(dto.Email);
            if (ModelState.IsValid && user == null)
            {
                //Odraditi maper
                User newUser = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    UserName = dto.Email,
                    Email = dto.Email
                };

                var result = await _authService.Create(newUser, dto.Password, dto.IsAdmin);
                if (result.Succeeded)
                {
                    return Ok(dto.IsAdmin ? "Admin " : "User " + "account created.");
                }
                else
                {
                    List<IdentityError> errors = result.Errors.ToList();
                    var errorMessage = string.Join(", ", errors.Select(e => e.Description));
                    return BadRequest(errorMessage);
                }
            }
            else
            {
                return user == null ? BadRequest("Something went wrong.") : 
                                      BadRequest("Account with entered email allready exits.");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO dto) 
        {
            var user = await _authService.FindByEmail(dto.Email);
            if (ModelState.IsValid && user == null) 
            {
                Customer newUser = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    UserName = dto.Email,
                    Email = dto.Email,
                    Tickets = new List<Ticket>()
                };
                var result = await _authService.Register(newUser, dto.Password);
                await _authService.SignIn(newUser);
                return Ok("Successful registration.");
            }
            else 
            {
                return user == null ? BadRequest("Something went wrong.") :
                                      BadRequest("Account with entered email allready exits.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto) 
        {
            if (ModelState.IsValid) 
            {
                var result = await _authService.Login(dto.Email, dto.Password, dto.RememberMe);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else if(result.IsNotAllowed)
                {
                    return BadRequest("Not allowed.");
                }

                return BadRequest("Invalid credentials.");
            }
            else 
            {
                return BadRequest("Invalid input, please try again.");
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout() 
        {
            await _authService.Logout();
            return Ok("Logged out!");
        }
    }
}