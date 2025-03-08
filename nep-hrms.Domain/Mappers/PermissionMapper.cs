using AutoMapper;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Mappers
{
    public class PermissionMapper: Profile
    {
        public PermissionMapper()
        {
            CreateMap<Permission, PermissionDto>();

            CreateMap<PermissionDto, Permission>();
        }
    }
}
