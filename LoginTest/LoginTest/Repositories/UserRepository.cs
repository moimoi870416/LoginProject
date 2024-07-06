using LoginTest.Models;
using LoginTest.Repositories.Models;
using static LoginTest.Controllers.Services.LoginService;

namespace LoginTest.Repositories
{
    public class UserRepository
    {
        //mock data
        private static List<UserEntity> mocks = new()
        {
            new UserEntity
            {
                Account = "admin",
                Password = "admin",
                Identity = Identity.Admin
            },
            new UserEntity
            {
                Account = "vip",
                Password = "vip",
                Identity = Identity.VIP
            },
            new UserEntity
            {
                Account = "regular",
                Password = "regular",
                Identity = Identity.Regular
            }
        };

        public bool TryGetUserByPassword(LoginRequest loginRequest, out UserModel user)
        {
            user = default;
            var matchedUser = mocks.FirstOrDefault(mock => mock.Account == loginRequest.Account &&
                                                           mock.Password == loginRequest.Password);
            if (matchedUser == null) return false;

            user = new UserModel
            {
                Account = matchedUser.Account,
                Identity = matchedUser.Identity
            };
            return true;
        }

        public bool TryFindUser(string account, out UserModel user)
        {
            user = default;
            var matchedUser = mocks.FirstOrDefault(mock => mock.Account == account);
            if (matchedUser == null) return false;

            user = new UserModel
            {
                Account = matchedUser.Account,
                Identity = matchedUser.Identity
            };
            return true;
        }

        public bool TrySetIdentity(string account, Identity identity, out UserModel user)
        {
            user = default;
            var matchedUser = mocks.FirstOrDefault(mock => mock.Account == account);
            if (matchedUser == null) return false;

            // Update the user's Identity in the list
            matchedUser.Identity = identity;

            // Return the updated user model
            user = new UserModel
            {
                Account = matchedUser.Account,
                Identity = matchedUser.Identity
            };
            return true;
        }
    }
}
