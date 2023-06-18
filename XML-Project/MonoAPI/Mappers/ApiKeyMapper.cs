using MonoAPI.DTOs.Auth;
using MonoLibrary.Core.Models;

namespace MonoAPI.Mappers
{
    public class ApiKeyMapper
    {
        public static ApiKeyResponse EntityToDto(ApiKey key) 
        {
            var response = new ApiKeyResponse
            {
                Id = key.Id,
                UserId = key.UserId,
                Key = key.Key,
                ExpireDate = key.Created.AddMinutes(key.ExpireIn)
            };

            return response;
        }
        
        public static List<ApiKeyResponse> EntityToDtoList(List<ApiKey> keys) 
        {
            List<ApiKeyResponse> response = new List<ApiKeyResponse>();
            keys.ForEach(item => 
            {
                response.Add(EntityToDto(item));
            });

            return response;
        }

    }
}
