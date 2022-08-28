// ***********************************************************************
// Assembly         : JGP.Members.Services
// Author           : Joshua Gwynn-Palmer
// Created          : 07-27-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-27-2022
// ***********************************************************************
// <copyright file="IRegistrationService.cs" company="JGP.Members.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Services;

using Core.Commands;
using JGP.Core.Services;

/// <summary>
///     Interface IRegistrationService
///     Implements the <see cref="System.IDisposable" />
/// </summary>
/// <seealso cref="System.IDisposable" />
public interface IRegistrationService : IDisposable
{
    /// <summary>
    ///     Register member as an asynchronous operation.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> RegisterMemberAsync(RegistrationCommand command);
}