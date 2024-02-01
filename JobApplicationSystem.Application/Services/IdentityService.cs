using AutoMapper;
using JobApplicationSystem.Application.DTOs.IdentityDTOs;
using JobApplicationSystem.Application.Responses;
using JobApplicationSystem.Application.Services.Interfaces;
using JobApplicationSystem.Application.Utility.Interfaces;
using JobApplicationSystem.Domain.Entity;
using JobApplicationSystem.Domain.StaticData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ApiResponse> RegisterAsync(RegisterDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
                return new ApiResponse(400, "This User Exists.");

            if (dto.Password != dto.ConfirmPassword)
                return new ApiResponse(400, "Password and Confirm Password do not Match.");

            var applicationUser = _mapper.Map<ApplicationUser>(dto);

            var result = await _userManager.CreateAsync(applicationUser, dto.Password);
            if (!result.Succeeded)
                return new ApiResponse(400, "Something went Wrong.");

            var addingUser = await _userManager.AddToRoleAsync(applicationUser, UserRoles.RegistredUser);
            if (addingUser.Succeeded)
                return new ApiResponse(200, "User was Registered. Please Login!");

            return new ApiResponse(400, "Something went Wrong.");
        }
        public async Task<JwtResponse> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return new JwtResponse(400, "Email was Incorrect.");

            var userPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!userPassword)
                return new JwtResponse(400, "Password was Incorrect.");

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles != null)
            {
                var jwtToken = _tokenGenerator.GenerateJwtToken(user, userRoles.ToList());
                var tokenExpiration = DateTime.Now.AddMinutes(30);
                var userId = user.Id;
                return new JwtResponse(200, "Successful Login.", jwtToken, tokenExpiration, userId, userRoles.ToList());
            }

            return new JwtResponse(400, "Something Went Wrong.");
        }
    }
}
