namespace JGP.Members.Api.Application.Configuration
{
    using JGP.Members.Data.EntityFramework;
    using JGP.Members.Services;
    using JGP.Security;
    using Microsoft.EntityFrameworkCore;

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
            services.AddTransient(provider => provider.GetService<HttpContext>()?.User);

            // Context.
            var connectionString = configuration.GetConnectionString("IdentityContext");
            services.AddDbContext<MemberContext>(options => options.UseSqlServer(connectionString,
                optionsBuilder => optionsBuilder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null)));

            // Services.
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
        }
    }
}
