using AutoMapper;
using JobApplicationSystem.Application.DTOs.IdentityUserDTOs;
using JobApplicationSystem.Application.Responses;
using JobApplicationSystem.Application.Services.Interfaces;
using JobApplicationSystem.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Application.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public IdentityUserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<GetUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<List<GetUserDto>>(users);

            foreach (var userDto in result)
            {
                var user = users.FirstOrDefault(u => u.Id == userDto.Id);
                if (user != null)
                {
                    userDto.Roles = (await _userManager.GetRolesAsync(user)).ToList();
                }
            }
            return result;
        }

        public async Task<ApiResponse> AddUserAsync(AddUserDTO dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return new ApiResponse(400, "A user with this email already exists.");

            var user = _mapper.Map<ApplicationUser>(dto);

            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
                return new ApiResponse(400, "Something went wrong while adding the user.");

            return new ApiResponse(200, "User added successfully.");
        }

        public async Task<ApiResponse> UpdateUserAsync(EditUserDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null) return new ApiResponse(404, "User not found.");

            if (user.FirstName == dto.FirstName &&
                user.LastName == dto.LastName &&
                user.Email == dto.Email &&
                user.DateOfBirth == dto.DateOfBirth &&
                user.Gender == dto.Gender &&
                user.UserName == dto.Username &&
                user.Nationality == dto.Nationality)
            { return new ApiResponse(400, "No changes were made."); }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.DateOfBirth = dto.DateOfBirth;
            user.Gender = dto.Gender;
            user.UserName = dto.Username;
            user.Nationality = dto.Nationality;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return new ApiResponse(200, "User updated successfully.");
            return new ApiResponse(400, "Failed to update user.");
        }

        public async Task<ApiResponse> DeleteUserAsync(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new ApiResponse(404, "User not found.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid)
                return new ApiResponse(401, "Invalid password. User not deleted.");

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded) return new ApiResponse(200, "User deleted successfully.");
            return new ApiResponse(400, "Failed to delete user.");
        }

        public async Task<GetUserDto> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return null;

            var dto = _mapper.Map<GetUserDto>(user);
            dto.Roles = (await _userManager.GetRolesAsync(user)).ToList();


            return dto;
        }
    }
}
