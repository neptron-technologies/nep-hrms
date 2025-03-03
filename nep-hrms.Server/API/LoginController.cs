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

        public async Task<IActionResult> GetUsersWithRolesAndPermissions([FromBody] UserRequest request)
        {
            var userDtos = await _loginService.GetUsersWithRolesAndPermissionsAsync(request);

            


            if (userDtos == null || !userDtos.Any())
            {  
               
                return Unauthorized("Invalid Username or Password");

            }
            return Ok(userDtos );
            

        }

        




    }
}
