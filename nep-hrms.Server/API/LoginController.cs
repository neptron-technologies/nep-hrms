using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;
using System.Reflection.Metadata.Ecma335;

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
        //[HttpPost]
        //[Route("LoginAsync")]
        //public async Task<IActionResult> LoginAsync(LoginInfo loginInfo)
        //{
        //    var result = _loginService.Login(loginInfo);
        //    if (result == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login(LoginInfo loginInfo)
        //{
        //    var result = _loginService.Login(loginInfo);
        //    if (result == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(result);
        //}


        
        [HttpGet("all")]
       
        public async Task<IActionResult> GetUserAsync()
        {

            var result = await _loginService.GetUsers();
            return Ok(result);
        }

    }
}
