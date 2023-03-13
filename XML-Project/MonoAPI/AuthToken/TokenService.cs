namespace MonoAPI.AuthToken
{
    public class TokenService : ITokenService
    {
        public TokenService()
        {

        }
        public Task<string> GetTokenAsync(string token)
        {
            
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
