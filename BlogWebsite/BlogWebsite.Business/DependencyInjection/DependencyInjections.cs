
using Microsoft.AspNetCore.Http;

namespace BlogWebsite.Business.DependencyInjection
{
    public static class DependencyInjections
    {
        public static IServiceCollection BusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
