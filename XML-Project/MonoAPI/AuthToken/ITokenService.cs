using MonoLibrary.Core.Models.ApplicationUsers;

namespace MonoAPI.AuthToken
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(string email, string role);
        bool ValidateToken(string token);  
    }
}
