using nep_hrms.Domain.Models;
using nep_hrms.Domain.RequestInfo;

namespace nep_hrms.Domain.Interfaces
{
    public interface ILoginService
    {
        public Task<UserDto> GetUserAsync(UserRequest userRequest);
    }
}