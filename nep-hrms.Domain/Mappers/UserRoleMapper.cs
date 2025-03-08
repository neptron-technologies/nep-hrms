using AutoMapper;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Mappers
{
    public class UserRoleMapper: Profile
    {
        public UserRoleMapper()
        {
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();
            //CreateMap<List<UserRoleDto>, List<UserRole>>();
            //CreateMap<List<UserRoleDto>, List<UserRole>>();
        }
    }
}
