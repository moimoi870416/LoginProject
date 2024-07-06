using LoginTest.Models;
using LoginTest.Processors;
using LoginTest.Extensions;
using System.IdentityModel.Tokens.Jwt;
using LoginTest.Repositories.Models;
using System.Security.Claims;
using LoginTest.Exceptions;

namespace LoginTest.Controllers.Pipelines.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtProcessor _jwtProcessor;

        public AuthMiddleware(RequestDelegate next,
                              JwtProcessor jwtProcessor)
        {
            _next = next;
            this._jwtProcessor = jwtProcessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Authorization", out var authValue)) throw new JwtException();

            var jwtToken = authValue.ToString();
            if (!_jwtProcessor.ValidateToken(jwtToken, out var claims)) throw new JwtException();

            UserModel userModel = GenerateUserModel(claims);
            context.Items.Add("userModel", userModel);

            await _next(context);
        }

        private static UserModel GenerateUserModel(ClaimsPrincipal claims)
        {
            var identityClaim = claims.FindFirst("identity") ?? throw new JwtException();
            var subClaim = claims.FindFirst(ClaimTypes.NameIdentifier) ?? throw new JwtException();
            return new UserModel
            {
                Account = subClaim.Value.ToString(),
                Identity = identityClaim.Value.ToString().ToEnum<Identity>()
            };
        }
    }
}
