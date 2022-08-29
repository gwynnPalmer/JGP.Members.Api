// ***********************************************************************
// Assembly         : JGP.Members.Api
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 08-28-2022
// ***********************************************************************
// <copyright file="LoggingConfiguration.cs" company="JGP.Members.Api">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Api.Application.Configuration
{
    using Core.Configuration;
    using Logging.NativeLogging;

    /// <summary>
    ///     Class LoggingConfiguration.
    /// </summary>
    internal static class LoggingConfiguration
    {
        /// <summary>
        ///     Configures the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="appSettings">The application settings.</param>
        public static void Configure(IServiceCollection services, IConfiguration configuration, AppSettings appSettings)
        {
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
                loggingBuilder.AddNativeLogger(options =>
                {
                    configuration.GetSection("Logging").GetSection("Native").GetSection("Options").Bind(options);
                });
            });
        }
    }
}