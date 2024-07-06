using LoginTest.Exceptions;
using LoginTest.Processors;
using LoginTest.Repositories;

namespace LoginTest.Controllers.Services
{
    public class LoginService
    {
        private readonly JwtProcessor _jwtProcessor;
        private readonly UserRepository _userRepository;

        public LoginService(JwtProcessor jwtProcessor,
                            UserRepository userRepository)
        {
            this._jwtProcessor = jwtProcessor;
            this._userRepository = userRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            if (!_userRepository.TryGetUserByPassword(loginRequest, out var user)) throw new LoginException();

            string jwtToken = _jwtProcessor.GenerateToken(new JwtProcessor.GenerateTokenParams { Account = user.Account, Identity = user.Identity});

            return new LoginResponse
            {
                JwtToken = jwtToken
            };
        }

        #region login params
        public class LoginRequest
        {
            public string Account { get; set; }

            public string Password { get; set; }
        }

        public class LoginResponse
        {
            public string JwtToken { get; set; }
        }
        #endregion
    }
}
