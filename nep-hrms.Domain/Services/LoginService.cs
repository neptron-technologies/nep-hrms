using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.ViewModels;

namespace nep_hrms.Domain.Services
{
    public class LoginService : ILoginService
    {
        public LoginResponseVM Login(LoginInfo loginInfo)
        {
            LoginResponseVM loginResponse = null;
            if (loginInfo != null)
            {
                loginResponse = new LoginResponseVM()
                {
                    UserId = loginInfo.UserId,
                    PassToken = loginInfo.PassToken
                };
            }
            return loginResponse;
        }
    }
}
