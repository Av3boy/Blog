namespace Blog.DependencyInjection
{
    /// <summary>Contains the configuration settings for the Web Application.</summary>
    public static class Configuration
    {
        /// <summary>
        ///     Configures the web application
        /// </summary>
        /// <param name="app">The application to be configured.</param>
        public static void Configure(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
        }
    }
}
