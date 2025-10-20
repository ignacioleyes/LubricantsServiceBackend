using AutoMapper;
using LubricantsServiceBackend.DTOs;
using LubricantsServiceBackend.Entities;

namespace LubricantsServiceBackend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, LoginDTO>();
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserCreationDTO, ApplicationUser>();

        }
    }
}
