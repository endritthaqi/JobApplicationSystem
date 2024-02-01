using AutoMapper;
using JobApplicationSystem.Application.DTOs.IdentityDTOs;
using JobApplicationSystem.Application.DTOs.IdentityUserDTOs;
using JobApplicationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Infrastructure.MappingProfiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
            CreateMap<LoginDTO, ApplicationUser>().ReverseMap();
            CreateMap<GetUserDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, AddUserDTO>()
                .ForMember(dest => dest.Roles, act => act.Ignore())
                .ReverseMap();
        }
    }
}
