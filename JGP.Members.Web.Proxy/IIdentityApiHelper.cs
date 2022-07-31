// ***********************************************************************
// Assembly         : JGP.Members.Web.Proxy
// Author           : Joshua Gwynn-Palmer
// Created          : 07-31-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-31-2022
// ***********************************************************************
// <copyright file="IIdentityApiHelper.cs" company="JGP.Members.Web.Proxy">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Web.Proxy;

using JGP.Core.Services;
using Models;
using Security;

/// <summary>
///     Interface IIdentityApiHelper
/// </summary>
public interface IIdentityApiHelper
{
    /// <summary>
    ///     Authenticate as an asynchronous operation.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A Task&lt;AuthenticationResultModel&gt; representing the asynchronous operation.</returns>
    Task<AuthenticationResultModel?> AuthenticateAsync(LoginModel model);

    /// <summary>
    ///     Register member as an asynchronous operation.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt?> RegisterMemberAsync(MemberRegistrationModel model);

    /// <summary>
    ///     Change password as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <param name="password">The password.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt?> ChangePasswordAsync(string emailAddress, string password);

    /// <summary>
    ///     Disable member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt?> DisableMemberAsync(string emailAddress);

    /// <summary>
    ///     Disable member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt?> DisableMemberAsync(Guid memberId);

    /// <summary>
    ///     Enable member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt?> EnableMemberAsync(string emailAddress);

    /// <summary>
    ///     Enable member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt?> EnableMemberAsync(Guid memberId);

    /// <summary>
    ///     Get member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;MemberModel&gt; representing the asynchronous operation.</returns>
    Task<MemberModel?> GetMemberAsync(string emailAddress);

    /// <summary>
    ///     Get member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;MemberModel&gt; representing the asynchronous operation.</returns>
    Task<MemberModel?> GetMemberAsync(Guid memberId);

    /// <summary>
    ///     Hash password as an asynchronous operation.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
    Task<string?> HashPasswordAsync(string password);

    /// <summary>
    ///     Verify password as an asynchronous operation.
    /// </summary>
    /// <param name="hashedPassword">The hashed password.</param>
    /// <param name="password">The password.</param>
    /// <returns>A Task&lt;VerificationResult&gt; representing the asynchronous operation.</returns>
    Task<VerificationResult?> VerifyPasswordAsync(string hashedPassword, string password);
}