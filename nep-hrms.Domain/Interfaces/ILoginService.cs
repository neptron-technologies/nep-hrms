using Microsoft.Identity.Client;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Repositories;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.ViewModels;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Interfaces
{
    public interface ILoginService
    {

        public Task<List<UserDto>> GetUsersWithRolesAndPermissionsAsync(UserRequest userRequest);





    }
}