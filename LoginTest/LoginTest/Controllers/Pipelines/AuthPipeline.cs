using LoginTest.Controllers.Pipelines.Middlewares;
using LoginTest.Repositories.Models;

namespace LoginTest.Controllers.Pipelines
{
    public class AuthPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<AuthMiddleware>();
        }

        public static UserModel GetUserModel(HttpContext httpContext)
        {
            return (UserModel)httpContext.Items["userModel"]!;
        }
    }
}
