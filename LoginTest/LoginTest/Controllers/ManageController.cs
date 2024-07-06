using LoginTest.Controllers.Pipelines;
using LoginTest.Controllers.Services;
using LoginTest.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using static LoginTest.Controllers.Services.ManageService;

namespace LoginTest.Controllers
{
    [ApiController]
    [Route("manage")]
    [MiddlewareFilter(typeof(AuthPipeline))]
    public class ManageController : ControllerBase
    {
        private readonly ManageService _manageService;
        private UserModel _userModel => AuthPipeline.GetUserModel(HttpContext);

        public ManageController(ManageService manageService)
        {
            this._manageService = manageService;
        }

        /// <summary>
        /// 權限設定。(管理員限定)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("permisson")]
        public async Task<PermissonResponse> SetPermisson(PermissonRequest request)
        {
            if(_userModel.Identity != Models.Identity.Admin) throw new UnauthorizedAccessException();
            PermissonResponse response = await _manageService.SetPermisson(request);
            return response;
        }
    }
}
