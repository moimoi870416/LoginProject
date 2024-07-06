using LoginTest.Controllers.Services;
using LoginTest.Processors;
using LoginTest.Repositories;

namespace LoginTest.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection collection)
        {
            //services
            collection.AddScoped<LoginService>();
            collection.AddScoped<UserService>();
            collection.AddScoped<ManageService>();

            //processors
            collection.AddSingleton<JwtProcessor>();

            //repositories
            collection.AddSingleton<UserRepository>();

            return collection;
        }
    }
}
