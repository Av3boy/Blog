using Blog.DependencyInjection.Services;

namespace Blog.DependencyInjection
{
    /// <summary>Handles the registraion of services for an application.</summary>
    public static class ServiceRegistrar
    {
        /// <summary>
        /// Add services to the DI container.
        /// </summary>
        /// <param name="services">Collection where services will be registered.</param>
        public static void RegisterServices(this IServiceCollection services)
        {
            // Add blazor 
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Cache for storing component assemblies
            services.AddScoped<IBlogCache, BlogCache>();
        }
    }
}
