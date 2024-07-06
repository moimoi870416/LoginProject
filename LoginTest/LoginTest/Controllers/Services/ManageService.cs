using LoginTest.Models;
using LoginTest.Repositories;

namespace LoginTest.Controllers.Services
{
    public class ManageService
    {
        private readonly UserRepository _userRepository;

        public ManageService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        internal async Task<PermissonResponse> SetPermisson(PermissonRequest request)
        {
            if (!_userRepository.TryFindUser(request.Account, out var userModel)) throw new Exception("no such user");
            if (userModel.Identity == Identity.Admin) throw new Exception("'admin' permission cannot be modified.");
            _userRepository.TrySetIdentity(account: request.Account,
                                           identity: request.Identity,
                                           out var _);
            return new PermissonResponse();
        }

        public class PermissonRequest
        {
            public string Account { get; set; }

            public Identity Identity { get; set; }
        }

        public class PermissonResponse
        {

        }
    }
}
