using JGP.Api.KeyManagement.Authentication.Extensions;
using JGP.Members.Data.EntityFramework;
using JGP.Members.Services;
using JGP.Security;
using Microsoft.EntityFrameworkCore;

namespace JGP.Members.Api.Application.Configuration;

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
            optionsBuilder =>
                optionsBuilder.UseNetTopologySuite().EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null)));

        services.AddMemoryCache();

        // Custom Api Key Middleware
        services.AddApiKeyManagement(configuration);

        // Services.
        services.AddTransient<IMemberContext, MemberContext>();
        services.AddTransient<IPasswordService, PasswordService>();
        services.AddTransient<IMemberService, MemberService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IRegistrationService, RegistrationService>();
    }
}