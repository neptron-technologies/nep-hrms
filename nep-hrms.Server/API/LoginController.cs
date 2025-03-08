using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.RequestInfo;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;
using System.Reflection.Metadata.Ecma335;
using nep_hrms.Server.Authenticate;
using nep_hrms.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace nep_hrms.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Auth _auth;
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService, Auth auth)
        {
            _auth = auth;
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> GetUserAsync(
            [FromBody] UserRequest request)
        {
            var user = await _loginService.GetUserAsync(request);
            var token = _auth.GenerateToken(request.UserName);

            if (user == null)
                return Unauthorized("Invalid Username or Password");
            else
            {
                user.Token = token;
                return Ok(user);
            }
               
        }
    }
}