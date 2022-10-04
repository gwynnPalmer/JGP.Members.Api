// ***********************************************************************
// Assembly         : JGP.Members.Api
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-30-2022
// ***********************************************************************
// <copyright file="SecurityConfiguration.cs" company="JGP.Members.Api">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using JGP.Api.KeyManagement.Authentication;
using JGP.Api.KeyManagement.Authentication.Extensions;

namespace JGP.Members.Api.Application.Configuration;

/// <summary>
///     Class SecurityConfiguration.
/// </summary>
internal static class SecurityConfiguration
{
    /// <summary>
    ///     Configures the specified services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <exception cref="System.InvalidOperationException">No {nameof(ApiKeyAuthenticationSettings)} found</exception>
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var settings = services.BuildServiceProvider().GetService<ApiKeyAuthenticationSettings>();
        if (settings == null)
        {
            throw new InvalidOperationException($"No {nameof(ApiKeyAuthenticationSettings)} found");
        }

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = ApiKeyAuthenticationSettings.DefaultScheme;
            options.DefaultChallengeScheme = ApiKeyAuthenticationSettings.DefaultScheme;
        }).AddApiKeyManagement(settings);
    }
}