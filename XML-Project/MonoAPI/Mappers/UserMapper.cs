using MonoAPI.DTOs.Users;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Models.Enums;

namespace MonoAPI.Mappers
{
    public class UserMapper
    {
        public static Customer DtoToEntity(RegisterUserDTO dto) 
        {
            Customer newUser = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.Email,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Jmbg = dto.Jmbg,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.isMale ? Gender.MALE : Gender.FEMALE
            };

            return newUser;
        } 
    }
}
