using JobApplicationSystem.Application.DTOs.IdentityDTOs;
using JobApplicationSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<ApiResponse> RegisterAsync(RegisterDTO dto);
        Task<JwtResponse> LoginAsync(LoginDTO dto);

    }
}
