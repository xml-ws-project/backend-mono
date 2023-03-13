namespace MonoAPI.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public Jwt Jwt { get; set; } = new Jwt();
    }
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresIn { get; set; }
    }
}
