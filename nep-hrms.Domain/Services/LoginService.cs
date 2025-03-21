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
        public async Task<UserDto> GetUserAsync(UserRequest userRequest)
        {

            var user = await _dbContext.Users
                .Include(u => u.UserRoles)
                .Where(u => u.Username == userRequest.UserName)
                .FirstOrDefaultAsync();

            var roles = user.UserRoles;
            var roleIds = user?.UserRoles.Select(u => u.RoleId).ToList();
            var permissionIds = _dbContext.RolePermissions
                                    .Where(rp => roleIds.Contains(rp.RoleId))
                                    .Select(rp => rp.PermissionId)
                                    .ToList();
            var permissions = _dbContext.Permissions.Where(p => permissionIds.Contains(p.Id)).ToList();

            if (user == null)
                throw new Exception("User not found");
            if (user.PasswordHash != userRequest.Password)
                throw new Exception("Incorrect password");

            UserDto userDto = new UserDto();
            userDto.EmpId = user.EmpId;
            userDto.Username = user.Username;

            userDto.Roles = _mapper.Map<List<UserRole>, List<UserRoleDto>>(roles);
            userDto.Permissions = _mapper.Map<List<Permission>, List<PermissionDto>>(permissions);

            return userDto;
        }
    }
}
