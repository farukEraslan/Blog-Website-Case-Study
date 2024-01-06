
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
            return services;
        }
    }
}
