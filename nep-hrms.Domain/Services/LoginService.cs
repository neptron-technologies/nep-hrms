using Azure.Core;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.ViewModels;
using nep_hrms.Server.nep_hrms.DAL;


namespace nep_hrms.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginService _loginService;
        private readonly HrmsDBContext _dbContext;
        public LoginService(ILoginService loginService)
        {
            //_dbContext = context;
            _loginService = loginService;


        }
        public async Task<List<UserDto>> GetUsersWithRolesAndPermissionsAsync(UserRequest userRequest)
        {
            var userEntities = await _dbContext.Users
        .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
        .FirstOrDefaultAsync(u => u.Username == userRequest.UserName);

          
            if (userEntities == null)
            {
                return new List<UserDto>();
            }


            var userDtos = new UserDto
            {
                Username = userEntities.Username,
                RoleNames = userEntities.UserRoles.Select(ur => ur.Role.RoleName).ToList(),
                Permissions = userEntities.UserRoles
                    .SelectMany(ur => ur.Role.RolePermissions)
                    .Select(rp => rp.Permission.PermissionType)
                    .ToList()

            };
                


                return new List<UserDto> { userDtos };
                
           



        }




    }
}
        







        






    
    
