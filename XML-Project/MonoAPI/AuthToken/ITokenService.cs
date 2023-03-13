namespace MonoAPI.AuthToken
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(string token);
        bool ValidateToken(string token);  
    }
}
