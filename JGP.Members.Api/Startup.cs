namespace JGP.Members.Api
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Application.Configuration;
    using Core.Configuration;
    using Data.EntityFramework;
    using JGP.Core.Serialization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Class Startup.
    /// </summary>
    internal class Startup
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        private IConfiguration Configuration { get; }

        /// <summary>
        ///     Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="appSettings">The application settings.</param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppSettings appSettings)
        {
            // TODO: Configure Logging.
            // app.UseSomeLogger?

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            SwaggerConfiguration.ConfigureApp(app, env);

            // Ensure migration of context.
            app.EnsureMigrationOfContext<MemberContext>();
        }

        /// <summary>
        ///     Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new ActionReceiptConverter());
            });

            // services.AddProblemDetails();

            IocConfiguration.Configure(services, Configuration);
            SecurityConfiguration.Configure(services, Configuration);
            SwaggerConfiguration.ConfigureServices(services);
            services.AddHealthChecks();
        }
    }
}