using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Server.nep_hrms.DAL;
using System.Data;

namespace nep_hrms.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly HrmsDBContext _dbContext;
        private readonly IMapper _mapper;
        public LoginService(HrmsDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUserAsync(
            UserRequest userRequest)
        {
            var user =
                await _dbContext.Users 
                    .Include(ur => ur.Roles)
                    //.ThenInclude(r => r.RolePermissions)
                    //.ThenInclude(rp => rp.Permissions)
                    .Where(u => u.Username == userRequest.UserName)
                    .FirstOrDefaultAsync();

            UserDto userDto = new UserDto();
            userDto.Username = user.Username;
            userDto.Roles = _mapper.Map<List<UserRole>, List<UserRoleDto>>(user.Roles);
            
            
            return userDto;
        }
    }
}
