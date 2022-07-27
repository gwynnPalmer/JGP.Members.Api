// ***********************************************************************
// Assembly         : JGP.Members.Services
// Author           : Joshua Gwynn-Palmer
// Created          : 07-27-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-27-2022
// ***********************************************************************
// <copyright file="RegistrationService.cs" company="JGP.Members.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Services;

using Core;
using Core.Commands;
using Data.EntityFramework;
using JGP.Core.Services;
using Microsoft.Extensions.Logging;
using Security;

/// <summary>
///     Class RegistrationService.
/// </summary>
public class RegistrationService : IRegistrationService
{
    /// <summary>
    ///     The logger
    /// </summary>
    private readonly ILogger<RegistrationService> _logger;

    /// <summary>
    ///     The member context
    /// </summary>
    private readonly IMemberContext _memberContext;

    /// <summary>
    ///     The password service
    /// </summary>
    private readonly IPasswordService _passwordService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RegistrationService" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="memberContext">The member context.</param>
    /// <param name="passwordService">The password service.</param>
    public RegistrationService(ILogger<RegistrationService> logger, IMemberContext memberContext,
        IPasswordService passwordService)
    {
        _logger = logger;
        _memberContext = memberContext;
        _passwordService = passwordService;
    }

    #region DISPOSAL

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        _memberContext?.Dispose();
        _passwordService?.Dispose();
    }

    #endregion

    /// <summary>
    ///     Register member as an asynchronous operation.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    public async Task<ActionReceipt> RegisterMemberAsync(MemberRegistrationCommand command)
    {
        try
        {
            command.PasswordHash = _passwordService.Hash(command.PasswordHash);

            var member = new Member(command);

            await _memberContext.Members.AddAsync(member);
            var affectedTotal = await _memberContext.SaveChangesAsync();
            return ActionReceipt.GetSuccessReceipt(affectedTotal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create member for {command.EmailAddress}");
            return ActionReceipt.GetErrorReceipt(ex);
        }
    }
}