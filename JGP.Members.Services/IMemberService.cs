// ***********************************************************************
// Assembly         : JGP.Members.Services
// Author           : Joshua Gwynn-Palmer
// Created          : 07-27-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="IMemberService.cs" company="JGP.Members.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Services;

using Core;
using Core.Commands;
using JGP.Core.Services;

/// <summary>
///     Interface IMemberService
///     Implements the <see cref="System.IDisposable" />
/// </summary>
/// <seealso cref="System.IDisposable" />
public interface IMemberService : IDisposable
{
    /// <summary>
    ///     Change password as an asynchronous operation.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> ChangePasswordAsync(ChangePasswordCommand command);

    /// <summary>
    ///     Disable member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> DisableMemberAsync(Guid memberId);

    /// <summary>
    ///     Disable member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> DisableMemberAsync(string emailAddress);

    /// <summary>
    ///     Enable member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> EnableMemberAsync(Guid memberId);

    /// <summary>
    ///     Enable member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> EnableMemberAsync(string emailAddress);

    /// <summary>
    ///     Get member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;Member&gt; representing the asynchronous operation.</returns>
    Task<Member?> GetMemberAsync(Guid memberId);

    /// <summary>
    ///     Get member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;Member&gt; representing the asynchronous operation.</returns>
    Task<Member?> GetMemberAsync(string emailAddress);

    /// <summary>
    ///     Update member as an asynchronous operation.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> UpdateMemberAsync(MemberUpdateCommand command);
}