using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.ViewModels;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Services
{
    public class LoginService : ILoginService
    {  private readonly ILoginRepo _loginRepo;
        

        public LoginService(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _loginRepo.GetAllAsync();
            return users;
        }

        //public async Task<List<User>> GetUser()
        //{
        //    var user = await _userRepo.GetAllAsync();
        //    return user;
        //} 

        //public async Task<LoginResponseVM> LoginAsync(LoginInfo loginInfo)
        //{
        //    LoginResponseVM loginResponse = null;
        //    if (loginInfo != null)
        //    {
        //        var users = await _userRepo.GetAllAsync();
        //        var user = users.Where(u => u.Username == loginInfo.UserName).FirstOrDefault();
        //    }
        //    return loginResponse;
        //}

        //public LoginResponseVM Login(LoginInfo loginInfo)
        //{
        //    LoginResponseVM loginResponse = null;
        //    if (loginInfo != null)
        //    {
        //        var users = _userRepo.GetAll();
        //        var user = users.Where(u => u.Username == loginInfo.UserName).FirstOrDefault();
        //    }
        //    return loginResponse;
        //}






    }
}
