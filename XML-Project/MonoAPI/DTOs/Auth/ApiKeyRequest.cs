using System.ComponentModel.DataAnnotations;

namespace MonoAPI.DTOs.Auth
{
    public class ApiKeyRequest
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int ExpireIn { get; set; }
    }
}
