namespace MonoAPI.DTOs.Auth
{
    public class ApiKeyResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Key { get; set; }
        public string ExpireDate{ get; set; }
    }
}
