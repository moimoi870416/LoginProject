using LoginTest.Controllers.Pipelines;
using LoginTest.Controllers.Services;
using LoginTest.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginTest.Controllers
{
    [ApiController]
    [Route("user")]
    [MiddlewareFilter(typeof(AuthPipeline))]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        //pre-resolve by middleware
        private UserModel _userModel => AuthPipeline.GetUserModel(HttpContext);

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// 取得帳戶資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet("info")]
        public async Task<UserInfoResponse> GetUserInfo()
        {
            UserInfoResponse response = await _userService.GetUserInfo(_userModel);
            return response;
        }
    }
}
