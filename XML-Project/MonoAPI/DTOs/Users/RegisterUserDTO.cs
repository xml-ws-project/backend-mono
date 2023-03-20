using System.ComponentModel.DataAnnotations;

namespace MonoAPI.DTOs.Users
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Jmbg { get; set; }

        [Required(ErrorMessage = "Required!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required!")]
        public bool isMale { get; set; }

        [Required(ErrorMessage = "Required!")]
        public DateTime DateOfBirth { get; set; }
        public bool IsAdmin { get; set; }
    }
}
