using JobApplicationSystem.Application.DTOs.IdentityUserDTOs;
using JobApplicationSystem.Application.Responses;
using JobApplicationSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagmentController : ControllerBase
    {
        private readonly IIdentityUserService _identityUserService;
        public UserManagmentController(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
        {
            return await _identityUserService.GetAllUsersAsync();
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<ApiResponse>> AddUser([FromBody] AddUserDTO dto)
        {
            var response = await _identityUserService.AddUserAsync(dto);
            return StatusCode(response.Status, response);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ApiResponse>> UpdateUser([FromForm] EditUserDTO dto)
        {
            return await _identityUserService.UpdateUserAsync(dto);
        }


        [HttpDelete("DeleteUserAccount")]
        public async Task<ActionResult<ApiResponse>> DeleteUser(string userId, string password)
        {
            return await _identityUserService.DeleteUserAsync(userId, password);
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<ActionResult<GetUserDto>> GetUserById(string userId)
        {
            var user = await _identityUserService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(user);
        }
    }
}
