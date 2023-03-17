using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MonoAPI.Configuration;
using MonoLibrary.Core.Models.ApplicationUsers;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MonoLibrary.Core.Services.Core;

namespace MonoAPI.AuthToken
{
    public class TokenService : ITokenService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public TokenService(ProjectConfiguration configuration, 
                            UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<string> CreateTokenAsync(string email, string role)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.Jwt.Key);
            var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
            var user = await _userManager.FindByEmailAsync(email);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("expiresIn", _configuration.Jwt.ExpiresIn.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(_configuration.Jwt.ExpiresIn),
                SigningCredentials = signinCredentials,
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            token = token.Replace("Bearer ", string.Empty);
            var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Jwt.Key));
            var handler = new JwtSecurityTokenHandler();

            try
            {
                handler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidIssuer = _configuration.Jwt.Issuer,
                    ValidAudience = _configuration.Jwt.Audience,
                    IssuerSigningKey = mySecurityKey,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,

                }, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
    
    }
}
