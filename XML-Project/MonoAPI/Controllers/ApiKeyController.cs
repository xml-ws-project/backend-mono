using Microsoft.AspNetCore.Mvc;
using MonoAPI.DTOs.Auth;
using MonoAPI.Mappers;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Services.Core;

namespace MonoAPI.Controllers
{
    [Route("api-key")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private readonly IApiKeyService _apiKeyService;

        public ApiKeyController(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }


        [HttpPost]
        public ActionResult<ApiKeyResponse> Create(ApiKeyRequest request)
        {
            var newKey = _apiKeyService.Create(request.UserId, request.ExpireIn);
            return Ok(ApiKeyMapper.EntityToDto(newKey));
        }

        [HttpGet]
        public ActionResult<List<ApiKeyResponse>> GetAll() 
        {
            var keys = _apiKeyService.GetAll();
            return Ok(ApiKeyMapper.EntityToDtoList(keys));
        }

        [HttpGet("{id}")]
        public ActionResult<List<ApiKeyResponse>> GetByUserId(string id)
        {
            var keys = _apiKeyService.GetByUserId(id);
            if (keys == null)
                return NotFound();

            return Ok(ApiKeyMapper.EntityToDtoList(keys));
        }

        [HttpPost("validate/{value}")]
        public ActionResult<bool> ValidateKey(string value) 
        {
            var response = _apiKeyService.Validate(value);
            return response ? Ok(response) : NotFound(response);
        }
    }
}
