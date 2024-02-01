using JobApplicationSystem.Application.DTOs.IdentityDTOs;
using JobApplicationSystem.Application.Responses;
using JobApplicationSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterAsync(RegisterDTO dto)
        {
            var response = await _identityService.RegisterAsync(dto);
            return StatusCode(response.Status, response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> LoginAsync([FromBody] LoginDTO dto)
        {
            var response = await _identityService.LoginAsync(dto);
            return StatusCode(response.Status, response);
        }


    }
}
