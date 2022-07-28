namespace JGP.Members.Api.Application.Configuration
{
    using Data.EntityFramework;
    using Microsoft.EntityFrameworkCore;
    using Security;
    using Services;

    internal static class IocConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            // AppSettings.
            var appSettings = AppSettingsConfiguration.Configure(configuration);
            services.AddSingleton(appSettings);

            // Configuration.
            services.AddSingleton(configuration);


            // Logging.
            LoggingConfiguration.Configure(services, configuration, appSettings);

            //
            //services.AddTransient(provider => provider.GetService<HttpContext>()?.User);

            // Context.
            var connectionString = configuration.GetConnectionString("IdentityContext");
            services.AddDbContext<MemberContext>(options => options.UseSqlServer(connectionString,
                optionsBuilder => optionsBuilder.UseNetTopologySuite().EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null)));

            // Services.
            services.AddTransient<IMemberContext, MemberContext>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
        }
    }
}