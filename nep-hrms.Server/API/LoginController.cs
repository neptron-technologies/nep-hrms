using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.Interfaces;

namespace nep_hrms.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            var result = _loginService.Login(loginInfo);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
