namespace JGP.Members.Api.Application.Configuration
{
    using Core.Configuration;

    internal static class LoggingConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration, AppSettings appSettings)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
        }
    }
}