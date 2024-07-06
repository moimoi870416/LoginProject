
using LoginTest.Repositories;

namespace LoginTest.Controllers.Services
{
    public class UserService
    {

        internal async Task<UserInfoResponse> GetUserInfo(Repositories.Models.UserModel _userModel)
        {
            return new UserInfoResponse
            {
                Account = _userModel.Account,
                Identity = _userModel.Identity.ToString()
            };
        }
    }

    #region userinfo param
    public class UserInfoResponse
    {
        public string Account { get;set; }

        public string Identity { get;set; }
    }
    #endregion
}
