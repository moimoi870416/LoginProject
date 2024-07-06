using LoginTest.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using static LoginTest.Controllers.Services.LoginService;

namespace LoginTest.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)        
        {
            this._loginService = loginService;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _loginService.Login(request);
        }
    }
}
