// ***********************************************************************
// Assembly         : JGP.Members.Services
// Author           : Joshua Gwynn-Palmer
// Created          : 07-28-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="IAuthenticationService.cs" company="JGP.Members.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Services;

using Core.Security;

/// <summary>
///     Interface IAuthenticationService
///     Implements the <see cref="IDisposable" />
/// </summary>
/// <seealso cref="IDisposable" />
public interface IAuthenticationService : IDisposable
{
    /// <summary>
    ///     Authenticate as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <param name="password">The password.</param>
    /// <returns>A Task&lt;AuthenticationResult&gt; representing the asynchronous operation.</returns>
    Task<AuthenticationResult> AuthenticateAsync(string emailAddress, string password);
}