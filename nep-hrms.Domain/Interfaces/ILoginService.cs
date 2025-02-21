using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.ViewModels;

namespace nep_hrms.Domain.Interfaces
{
    public interface ILoginService
    {
        public LoginResponseVM Login(LoginInfo loginInfo);
    }
}
