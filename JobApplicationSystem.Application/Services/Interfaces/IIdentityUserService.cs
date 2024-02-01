using JobApplicationSystem.Application.DTOs.IdentityUserDTOs;
using JobApplicationSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Application.Services.Interfaces
{
    public interface IIdentityUserService
    {
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<ApiResponse> AddUserAsync(AddUserDTO dto);
        Task<ApiResponse> UpdateUserAsync(EditUserDTO dto);
        Task<ApiResponse> DeleteUserAsync(string userId, string password);
        Task<GetUserDto> GetUserByIdAsync(string userId);

    }
}
